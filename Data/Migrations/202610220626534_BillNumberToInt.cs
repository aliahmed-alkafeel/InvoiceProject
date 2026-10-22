namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BillNumberToInt : DbMigration
    {
        public override void Up()
        {
            // تحويل أرقام الفواتير النصية (مثل BILL-0001) إلى أرقام صحيحة قبل تغيير نوع العمود
            Sql(@"UPDATE dbo.Bills
                  SET BillNumber = CAST(
                        CASE
                            WHEN PATINDEX('%[0-9]%', BillNumber) > 0
                                THEN TRY_CONVERT(INT, SUBSTRING(BillNumber, PATINDEX('%[0-9]%', BillNumber), 20))
                            ELSE ISNULL((SELECT MAX(TRY_CONVERT(INT, LTRIM(RTRIM(b2.BillNumber)))) FROM dbo.Bills b2), 0) + 1
                        END
                  AS NVARCHAR(20))");

            AlterColumn("dbo.Bills", "BillNumber", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Bills", "BillNumber", c => c.String(nullable: false, maxLength: 50));

            // إرجاع أرقام الفواتير إلى صيغة نصية (BILL-0001)
            Sql(@"UPDATE dbo.Bills
                  SET BillNumber = 'BILL-' + RIGHT('0000' + CAST(BillNumber AS NVARCHAR(10)), 4)");
        }
    }
}
