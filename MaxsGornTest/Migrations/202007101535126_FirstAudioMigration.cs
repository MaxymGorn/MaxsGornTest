namespace MaxsGornTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstAudioMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sounds",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sounds", "UserId", "dbo.Users");
            DropIndex("dbo.Sounds", new[] { "UserId" });
            DropTable("dbo.Users");
            DropTable("dbo.Sounds");
        }
    }
}
