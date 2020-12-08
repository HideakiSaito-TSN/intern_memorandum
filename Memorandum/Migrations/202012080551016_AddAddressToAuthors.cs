namespace Memorandum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAddressToAuthors : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Islogin = c.Boolean(nullable: false),
                        Admin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Goals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Isdoing = c.Boolean(nullable: false),
                        Content = c.String(),
                        Isdone = c.Boolean(nullable: false),
                        Account_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.Account_Id)
                .Index(t => t.Account_Id);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SenderID = c.Int(nullable: false),
                        Sentence = c.String(),
                        Time = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Reactions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SenderID = c.Int(nullable: false),
                        Type = c.Int(nullable: false),
                        Message_ID = c.Int(),
                        Account_Id = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Messages", t => t.Message_ID)
                .ForeignKey("dbo.Accounts", t => t.Account_Id)
                .Index(t => t.Message_ID)
                .Index(t => t.Account_Id);
            
            CreateTable(
                "dbo.MessageAccounts",
                c => new
                    {
                        Message_ID = c.Int(nullable: false),
                        Account_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Message_ID, t.Account_Id })
                .ForeignKey("dbo.Messages", t => t.Message_ID, cascadeDelete: true)
                .ForeignKey("dbo.Accounts", t => t.Account_Id, cascadeDelete: true)
                .Index(t => t.Message_ID)
                .Index(t => t.Account_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reactions", "Account_Id", "dbo.Accounts");
            DropForeignKey("dbo.Reactions", "Message_ID", "dbo.Messages");
            DropForeignKey("dbo.MessageAccounts", "Account_Id", "dbo.Accounts");
            DropForeignKey("dbo.MessageAccounts", "Message_ID", "dbo.Messages");
            DropForeignKey("dbo.Goals", "Account_Id", "dbo.Accounts");
            DropIndex("dbo.MessageAccounts", new[] { "Account_Id" });
            DropIndex("dbo.MessageAccounts", new[] { "Message_ID" });
            DropIndex("dbo.Reactions", new[] { "Account_Id" });
            DropIndex("dbo.Reactions", new[] { "Message_ID" });
            DropIndex("dbo.Goals", new[] { "Account_Id" });
            DropTable("dbo.MessageAccounts");
            DropTable("dbo.Reactions");
            DropTable("dbo.Messages");
            DropTable("dbo.Goals");
            DropTable("dbo.Accounts");
        }
    }
}
