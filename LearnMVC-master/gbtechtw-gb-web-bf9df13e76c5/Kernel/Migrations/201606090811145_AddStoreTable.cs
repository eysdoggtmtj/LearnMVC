namespace Kernel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStoreTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Latitude = c.Double(nullable: false),
                        Longitude = c.Double(nullable: false),
                        CreatedTime = c.DateTime(nullable: false),
                        ModifiedTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Stores");
        }
    }
}
