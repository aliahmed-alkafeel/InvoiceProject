namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountsTrees",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ParentGuid = c.Guid(),
                        AccountCode = c.String(nullable: false, maxLength: 50),
                        AccountName = c.String(nullable: false, maxLength: 200),
                        IsLeaf = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreatedById = c.Guid(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        IsUpdated = c.Boolean(nullable: false),
                        UpdatedById = c.Guid(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedById = c.Guid(),
                        DeletedAt = c.DateTime(),
                        Notes = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AccountsTrees", t => t.ParentGuid)
                .Index(t => t.ParentGuid);
            
            CreateTable(
                "dbo.Bills",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        BillNumber = c.String(nullable: false, maxLength: 50),
                        BillType = c.Int(nullable: false),
                        AccountTreeGuid = c.Guid(nullable: false),
                        CurrencyGuid = c.Guid(nullable: false),
                        CurrencyEqualValue = c.Decimal(nullable: false, precision: 18, scale: 6),
                        Date = c.DateTime(nullable: false),
                        Note = c.String(),
                        CreatedById = c.Guid(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        IsUpdated = c.Boolean(nullable: false),
                        UpdatedById = c.Guid(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedById = c.Guid(),
                        DeletedAt = c.DateTime(),
                        Notes = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AccountsTrees", t => t.AccountTreeGuid, cascadeDelete: true)
                .ForeignKey("dbo.Currencies", t => t.CurrencyGuid, cascadeDelete: true)
                .Index(t => t.AccountTreeGuid)
                .Index(t => t.CurrencyGuid);
            
            CreateTable(
                "dbo.BillItems",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        BillGuid = c.Guid(nullable: false),
                        ItemGuid = c.Guid(nullable: false),
                        Qty = c.Decimal(nullable: false, precision: 18, scale: 3),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedById = c.Guid(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        IsUpdated = c.Boolean(nullable: false),
                        UpdatedById = c.Guid(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedById = c.Guid(),
                        DeletedAt = c.DateTime(),
                        Notes = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bills", t => t.BillGuid, cascadeDelete: true)
                .ForeignKey("dbo.Items", t => t.ItemGuid, cascadeDelete: true)
                .Index(t => t.BillGuid)
                .Index(t => t.ItemGuid);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CategoryGuid = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 200),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsActive = c.Boolean(nullable: false),
                        CreatedById = c.Guid(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        IsUpdated = c.Boolean(nullable: false),
                        UpdatedById = c.Guid(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedById = c.Guid(),
                        DeletedAt = c.DateTime(),
                        Notes = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryGuid, cascadeDelete: true)
                .Index(t => t.CategoryGuid);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 200),
                        IsActive = c.Boolean(nullable: false),
                        CreatedById = c.Guid(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        IsUpdated = c.Boolean(nullable: false),
                        UpdatedById = c.Guid(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedById = c.Guid(),
                        DeletedAt = c.DateTime(),
                        Notes = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Currencies",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CurrencyName = c.String(nullable: false, maxLength: 50),
                        CurrencySymbol = c.String(nullable: false, maxLength: 10),
                        CurrencyEqual = c.Decimal(nullable: false, precision: 18, scale: 6),
                        IsMain = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreatedById = c.Guid(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        IsUpdated = c.Boolean(nullable: false),
                        UpdatedById = c.Guid(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedById = c.Guid(),
                        DeletedAt = c.DateTime(),
                        Notes = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Vouchers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        AccountTreeGuid = c.Guid(nullable: false),
                        VoucherNumber = c.String(nullable: false, maxLength: 50),
                        VoucherType = c.Int(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CurrencyGuid = c.Guid(nullable: false),
                        CurrencyEqualValue = c.Decimal(nullable: false, precision: 18, scale: 6),
                        Date = c.DateTime(nullable: false),
                        CreatedById = c.Guid(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        IsUpdated = c.Boolean(nullable: false),
                        UpdatedById = c.Guid(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedById = c.Guid(),
                        DeletedAt = c.DateTime(),
                        Notes = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AccountsTrees", t => t.AccountTreeGuid, cascadeDelete: true)
                .ForeignKey("dbo.Currencies", t => t.CurrencyGuid, cascadeDelete: true)
                .Index(t => t.AccountTreeGuid)
                .Index(t => t.CurrencyGuid);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        GroupGuid = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        PhoneNumber = c.String(nullable: false, maxLength: 20),
                        EmployeeStartingDate = c.DateTime(nullable: false),
                        EmployeeEndingDate = c.DateTime(),
                        Email = c.String(nullable: false, maxLength: 100),
                        Username = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 512),
                        CreatedById = c.Guid(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        IsUpdated = c.Boolean(nullable: false),
                        UpdatedById = c.Guid(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedById = c.Guid(),
                        DeletedAt = c.DateTime(),
                        Notes = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Groups", t => t.GroupGuid, cascadeDelete: true)
                .Index(t => t.GroupGuid);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        GroupName = c.String(nullable: false, maxLength: 200),
                        CreatedById = c.Guid(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        IsUpdated = c.Boolean(nullable: false),
                        UpdatedById = c.Guid(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedById = c.Guid(),
                        DeletedAt = c.DateTime(),
                        Notes = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GroupRoles",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        RoleGuid = c.Guid(nullable: false),
                        GroupGuid = c.Guid(nullable: false),
                        CreatedById = c.Guid(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        IsUpdated = c.Boolean(nullable: false),
                        UpdatedById = c.Guid(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedById = c.Guid(),
                        DeletedAt = c.DateTime(),
                        Notes = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Groups", t => t.GroupGuid, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.RoleGuid, cascadeDelete: true)
                .Index(t => t.RoleGuid)
                .Index(t => t.GroupGuid);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        RoleName = c.Int(nullable: false),
                        CreatedById = c.Guid(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        IsUpdated = c.Boolean(nullable: false),
                        UpdatedById = c.Guid(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedById = c.Guid(),
                        DeletedAt = c.DateTime(),
                        Notes = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GroupRoles", "RoleGuid", "dbo.Roles");
            DropForeignKey("dbo.GroupRoles", "GroupGuid", "dbo.Groups");
            DropForeignKey("dbo.Employees", "GroupGuid", "dbo.Groups");
            DropForeignKey("dbo.AccountsTrees", "ParentGuid", "dbo.AccountsTrees");
            DropForeignKey("dbo.Vouchers", "CurrencyGuid", "dbo.Currencies");
            DropForeignKey("dbo.Vouchers", "AccountTreeGuid", "dbo.AccountsTrees");
            DropForeignKey("dbo.Bills", "CurrencyGuid", "dbo.Currencies");
            DropForeignKey("dbo.Items", "CategoryGuid", "dbo.Categories");
            DropForeignKey("dbo.BillItems", "ItemGuid", "dbo.Items");
            DropForeignKey("dbo.BillItems", "BillGuid", "dbo.Bills");
            DropForeignKey("dbo.Bills", "AccountTreeGuid", "dbo.AccountsTrees");
            DropIndex("dbo.GroupRoles", new[] { "GroupGuid" });
            DropIndex("dbo.GroupRoles", new[] { "RoleGuid" });
            DropIndex("dbo.Employees", new[] { "GroupGuid" });
            DropIndex("dbo.Vouchers", new[] { "CurrencyGuid" });
            DropIndex("dbo.Vouchers", new[] { "AccountTreeGuid" });
            DropIndex("dbo.Items", new[] { "CategoryGuid" });
            DropIndex("dbo.BillItems", new[] { "ItemGuid" });
            DropIndex("dbo.BillItems", new[] { "BillGuid" });
            DropIndex("dbo.Bills", new[] { "CurrencyGuid" });
            DropIndex("dbo.Bills", new[] { "AccountTreeGuid" });
            DropIndex("dbo.AccountsTrees", new[] { "ParentGuid" });
            DropTable("dbo.Roles");
            DropTable("dbo.GroupRoles");
            DropTable("dbo.Groups");
            DropTable("dbo.Employees");
            DropTable("dbo.Vouchers");
            DropTable("dbo.Currencies");
            DropTable("dbo.Categories");
            DropTable("dbo.Items");
            DropTable("dbo.BillItems");
            DropTable("dbo.Bills");
            DropTable("dbo.AccountsTrees");
        }
    }
}
