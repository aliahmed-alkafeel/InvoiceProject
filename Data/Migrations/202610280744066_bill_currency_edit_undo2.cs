namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bill_currency_edit_undo2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bills", "CurrencyEqualValue", c => c.Decimal(nullable: false, precision: 18, scale: 6));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bills", "CurrencyEqualValue");
        }
    }
}
