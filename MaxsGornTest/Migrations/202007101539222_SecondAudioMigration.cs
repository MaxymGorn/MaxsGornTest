namespace MaxsGornTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondAudioMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sounds", "DateStart", c => c.DateTime(nullable: false));
            AddColumn("dbo.Sounds", "Duration", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sounds", "Duration");
            DropColumn("dbo.Sounds", "DateStart");
        }
    }
}
