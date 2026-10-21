namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class notedeleted1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Bills", "BillType", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Vouchers", "VoucherType", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Roles", "RoleName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Roles", "RoleName", c => c.Int(nullable: false));
            AlterColumn("dbo.Vouchers", "VoucherType", c => c.Int(nullable: false));
            AlterColumn("dbo.Bills", "BillType", c => c.Int(nullable: false));
        }
    }
}