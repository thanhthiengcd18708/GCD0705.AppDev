namespace GCD0705.AppDev.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFKToTaskModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tasks", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Tasks", "CategoryId");
            AddForeignKey("dbo.Tasks", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Tasks", new[] { "CategoryId" });
            DropColumn("dbo.Tasks", "CategoryId");
        }
    }
}
