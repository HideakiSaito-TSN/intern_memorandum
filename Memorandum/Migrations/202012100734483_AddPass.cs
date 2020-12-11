namespace Memorandum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accounts", "Pass", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Accounts", "Pass");
        }
    }
}
