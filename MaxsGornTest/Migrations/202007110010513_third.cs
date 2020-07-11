namespace MaxsGornTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class third : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sounds", "FileNameUrl", c => c.String());
            AddColumn("dbo.Users", "value", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "value");
            DropColumn("dbo.Sounds", "FileNameUrl");
        }
    }
}
