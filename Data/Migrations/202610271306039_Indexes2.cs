namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Indexes2 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.AccountsTrees", "UX_AccountsTree_AccountCode");
            DropIndex("dbo.Bills", "UX_Bills_Type_Number");
            DropIndex("dbo.Items", "UX_Items_Category_Name");
            DropIndex("dbo.Categories", "UX_Categories_Name");
            DropIndex("dbo.Currencies", "UX_Currency_Name");
            DropIndex("dbo.Currencies", "UX_Currency_Symbol");
            DropIndex("dbo.Vouchers", "UX_Vouchers_Type_Number");
            RenameIndex(table: "dbo.Employees", name: "UX_Employee_Email_IsDeleted_DeletedAt", newName: "UX_Employee_Email_Del");
            RenameIndex(table: "dbo.Employees", name: "UX_Employee_Username_IsDeleted_DeletedAt", newName: "UX_Employee_Username_Del");
            RenameIndex(table: "dbo.Groups", name: "UX_Group_Name_IsDeleted_DeletedAt", newName: "UX_Group_Name_Del");
            CreateIndex("dbo.AccountsTrees", new[] { "AccountCode", "IsDeleted", "DeletedAt" }, unique: true, name: "UX_AccountsTree_Code_Del");
            CreateIndex("dbo.AccountsTrees", new[] { "AccountName", "IsDeleted", "DeletedAt" }, unique: true, name: "UX_AccountsTree_Name_Del");
            CreateIndex("dbo.Bills", new[] { "BillNumber", "IsDeleted", "DeletedAt" }, unique: true, name: "UX_Bill_Number_Del");
            CreateIndex("dbo.Items", "CategoryGuid");
            CreateIndex("dbo.Items", new[] { "Name", "IsDeleted", "DeletedAt" }, unique: true, name: "UX_Item_Name_Del");
            CreateIndex("dbo.Categories", new[] { "Name", "IsDeleted", "DeletedAt" }, unique: true, name: "UX_Category_Name_Del");
            CreateIndex("dbo.Currencies", new[] { "CurrencyName", "IsDeleted", "DeletedAt" }, unique: true, name: "UX_Currency_Name_Del");
            CreateIndex("dbo.Currencies", new[] { "CurrencySymbol", "IsDeleted", "DeletedAt" }, unique: true, name: "UX_Currency_Symbol_Del");
            CreateIndex("dbo.Vouchers", new[] { "VoucherNumber", "IsDeleted", "DeletedAt" }, unique: true, name: "UX_Voucher_Number_Del");
            CreateIndex("dbo.Employees", new[] { "PhoneNumber", "IsDeleted", "DeletedAt" }, unique: true, name: "UX_Employee_Phone_Del");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Employees", "UX_Employee_Phone_Del");
            DropIndex("dbo.Vouchers", "UX_Voucher_Number_Del");
            DropIndex("dbo.Currencies", "UX_Currency_Symbol_Del");
            DropIndex("dbo.Currencies", "UX_Currency_Name_Del");
            DropIndex("dbo.Categories", "UX_Category_Name_Del");
            DropIndex("dbo.Items", "UX_Item_Name_Del");
            DropIndex("dbo.Items", new[] { "CategoryGuid" });
            DropIndex("dbo.Bills", "UX_Bill_Number_Del");
            DropIndex("dbo.AccountsTrees", "UX_AccountsTree_Name_Del");
            DropIndex("dbo.AccountsTrees", "UX_AccountsTree_Code_Del");
            RenameIndex(table: "dbo.Groups", name: "UX_Group_Name_Del", newName: "UX_Group_Name_IsDeleted_DeletedAt");
            RenameIndex(table: "dbo.Employees", name: "UX_Employee_Username_Del", newName: "UX_Employee_Username_IsDeleted_DeletedAt");
            RenameIndex(table: "dbo.Employees", name: "UX_Employee_Email_Del", newName: "UX_Employee_Email_IsDeleted_DeletedAt");
            CreateIndex("dbo.Vouchers", new[] { "VoucherType", "VoucherNumber" }, unique: true, name: "UX_Vouchers_Type_Number");
            CreateIndex("dbo.Currencies", "CurrencySymbol", unique: true, name: "UX_Currency_Symbol");
            CreateIndex("dbo.Currencies", "CurrencyName", unique: true, name: "UX_Currency_Name");
            CreateIndex("dbo.Categories", "Name", unique: true, name: "UX_Categories_Name");
            CreateIndex("dbo.Items", new[] { "CategoryGuid", "Name" }, unique: true, name: "UX_Items_Category_Name");
            CreateIndex("dbo.Bills", new[] { "BillType", "BillNumber" }, unique: true, name: "UX_Bills_Type_Number");
            CreateIndex("dbo.AccountsTrees", "AccountCode", unique: true, name: "UX_AccountsTree_AccountCode");
        }
    }
}
