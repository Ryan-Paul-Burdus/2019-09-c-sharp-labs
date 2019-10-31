namespace lab_49_MVC_users_categories_todoitems.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserLoggedIn : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CtegoryName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.ToDoItems",
                c => new
                    {
                        ToDoItemId = c.Int(nullable: false, identity: true),
                        Item = c.String(maxLength: 50, unicode: false),
                        DateDue = c.DateTime(storeType: "date"),
                        Done = c.Boolean(),
                        UserId = c.Int(),
                        CategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.ToDoItemId)
                .ForeignKey("dbo.Categories", t => t.CategoryId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(maxLength: 50),
                        LastLoggedIn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ToDoItems", "UserId", "dbo.Users");
            DropForeignKey("dbo.ToDoItems", "CategoryId", "dbo.Categories");
            DropIndex("dbo.ToDoItems", new[] { "CategoryId" });
            DropIndex("dbo.ToDoItems", new[] { "UserId" });
            DropTable("dbo.Users");
            DropTable("dbo.ToDoItems");
            DropTable("dbo.Categories");
        }
    }
}
