namespace Kernel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMyClassTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MyClasses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        CreatedTime = c.DateTime(nullable: false),
                        ModifiedTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MyClasses");
        }
    }
}
