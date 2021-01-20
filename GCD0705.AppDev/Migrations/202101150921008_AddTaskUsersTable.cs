namespace GCD0705.AppDev.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTaskUsersTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TaskUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApplicationUserId = c.String(nullable: false, maxLength: 128),
                        TaskId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tasks", t => t.TaskId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId, cascadeDelete: true)
                .Index(t => t.ApplicationUserId)
                .Index(t => t.TaskId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TaskUsers", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.TaskUsers", "TaskId", "dbo.Tasks");
            DropIndex("dbo.TaskUsers", new[] { "TaskId" });
            DropIndex("dbo.TaskUsers", new[] { "ApplicationUserId" });
            DropTable("dbo.TaskUsers");
        }
    }
}
