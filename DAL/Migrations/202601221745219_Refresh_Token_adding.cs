namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Refresh_Token_adding : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "IsDeleted", c => c.Boolean(nullable: false, defaultValue:false));
            AddColumn("dbo.Tokens", "RefreshToken", c => c.String(nullable: false, defaultValue:"Token Will add"));
            AddColumn("dbo.Tokens", "ExpiredAt", c => c.DateTime(nullable: false, defaultValueSql:"GETDATE()"));
            AlterColumn("dbo.Tokens", "TokenKey", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tokens", "TokenKey", c => c.String(nullable: false, maxLength: 100));
            DropColumn("dbo.Tokens", "ExpiredAt");
            DropColumn("dbo.Tokens", "RefreshToken");
            DropColumn("dbo.Products", "IsDeleted");
        }
    }
}
