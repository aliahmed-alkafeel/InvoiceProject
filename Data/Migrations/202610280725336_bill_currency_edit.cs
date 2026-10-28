namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bill_currency_edit : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Bills", "CurrencyEqualValue");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bills", "CurrencyEqualValue", c => c.Decimal(nullable: false, precision: 18, scale: 6));
        }
    }
}
