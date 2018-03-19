namespace TaskManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigr : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 128),
                        UserId = c.Int(nullable: false),
                        Deadline = c.DateTime(nullable: false),
                        Description = c.String(),
                        Status = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 20),
                        Password = c.String(nullable: false, maxLength: 15),
                        Email = c.String(),
                        UserStatus = c.Byte(nullable: false),
                        relatedUserStatus_Id = c.Int(),
                        Tasks_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserStatus", t => t.relatedUserStatus_Id)
                .ForeignKey("dbo.Tasks", t => t.Tasks_Id)
                .Index(t => t.relatedUserStatus_Id)
                .Index(t => t.Tasks_Id);
            
            CreateTable(
                "dbo.UserStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Tasks_Id", "dbo.Tasks");
            DropForeignKey("dbo.Users", "relatedUserStatus_Id", "dbo.UserStatus");
            DropIndex("dbo.Users", new[] { "Tasks_Id" });
            DropIndex("dbo.Users", new[] { "relatedUserStatus_Id" });
            DropTable("dbo.UserStatus");
            DropTable("dbo.Users");
            DropTable("dbo.Tasks");
        }
    }
}
