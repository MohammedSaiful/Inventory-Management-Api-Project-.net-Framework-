namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixUserTypeRequiredTokenTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tokens", "UserType", c => c.String(nullable: false, maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tokens", "UserType", c => c.String());
        }
    }
}
