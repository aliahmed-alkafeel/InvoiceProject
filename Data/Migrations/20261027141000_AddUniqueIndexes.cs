namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUniqueIndexes : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Groups", new[] { "GroupName", "IsDeleted", "DeletedAt" }, unique: true, name: "UX_Group_Name_IsDeleted_DeletedAt");
            CreateIndex("dbo.GroupRoles", new[] { "GroupGuid", "RoleGuid", "DeletedAt", "IsDeleted" }, unique: true, name: "UX_GroupRole_Group_Role_DeletedAt_IsDeleted");
            CreateIndex("dbo.Employees", new[] { "Email", "IsDeleted", "DeletedAt" }, unique: true, name: "UX_Employee_Email_IsDeleted_DeletedAt");
            CreateIndex("dbo.Employees", new[] { "Username", "IsDeleted", "DeletedAt" }, unique: true, name: "UX_Employee_Username_IsDeleted_DeletedAt");
            CreateIndex("dbo.Categories", "Name", unique: true, name: "UX_Categories_Name");
            CreateIndex("dbo.Items", new[] { "CategoryGuid", "Name" }, unique: true, name: "UX_Items_Category_Name");
            CreateIndex("dbo.Bills", new[] { "BillType", "BillNumber" }, unique: true, name: "UX_Bills_Type_Number");
            CreateIndex("dbo.AccountsTrees", "AccountCode", unique: true, name: "UX_AccountsTree_AccountCode");
            CreateIndex("dbo.Currencies", "CurrencyName", unique: true, name: "UX_Currency_Name");
            CreateIndex("dbo.Currencies", "CurrencySymbol", unique: true, name: "UX_Currency_Symbol");
            CreateIndex("dbo.Vouchers", new[] { "VoucherType", "VoucherNumber" }, unique: true, name: "UX_Vouchers_Type_Number");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Vouchers", "UX_Vouchers_Type_Number");
            DropIndex("dbo.Currencies", "UX_Currency_Symbol");
            DropIndex("dbo.Currencies", "UX_Currency_Name");
            DropIndex("dbo.AccountsTrees", "UX_AccountsTree_AccountCode");
            DropIndex("dbo.Bills", "UX_Bills_Type_Number");
            DropIndex("dbo.Items", "UX_Items_Category_Name");
            DropIndex("dbo.Categories", "UX_Categories_Name");
            DropIndex("dbo.Employees", "UX_Employee_Username_IsDeleted_DeletedAt");
            DropIndex("dbo.Employees", "UX_Employee_Email_IsDeleted_DeletedAt");
            DropIndex("dbo.GroupRoles", "UX_GroupRole_Group_Role_DeletedAt_IsDeleted");
            DropIndex("dbo.Groups", "UX_Group_Name_IsDeleted_DeletedAt");
        }
    }
}
