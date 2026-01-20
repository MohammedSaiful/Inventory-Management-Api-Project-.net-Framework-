namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserTypeToToken : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tokens", "UserType", c => c.String(nullable: false, maxLength: 20, defaultValue: "User"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tokens", "UserType");
        }
    }
}
