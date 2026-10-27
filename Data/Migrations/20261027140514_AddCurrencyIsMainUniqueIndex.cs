namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCurrencyIsMainUniqueIndex : DbMigration
    {
        public override void Up()
        {
            Sql("CREATE UNIQUE INDEX UX_Currency_IsMain ON Currency(IsMain) WHERE IsMain = 1");
        }
        
        public override void Down()
        {
            Sql("DROP INDEX UX_Currency_IsMain ON Currency");
        }
    }
}
