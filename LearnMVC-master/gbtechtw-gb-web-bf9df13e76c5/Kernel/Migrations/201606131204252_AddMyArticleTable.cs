namespace Kernel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMyArticleTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MyArticles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        Content = c.String(),
                        MyClassId = c.Int(nullable: false),
                        CreatedTime = c.DateTime(nullable: false),
                        ModifiedTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MyClasses", t => t.MyClassId, cascadeDelete: true)
                .Index(t => t.MyClassId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MyArticles", "MyClassId", "dbo.MyClasses");
            DropIndex("dbo.MyArticles", new[] { "MyClassId" });
            DropTable("dbo.MyArticles");
        }
    }
}
