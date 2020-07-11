namespace MaxsGornTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Sounds", "DateStart", c => c.String());
            AlterColumn("dbo.Sounds", "Duration", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Sounds", "Duration", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Sounds", "DateStart", c => c.DateTime(nullable: false));
        }
    }
}
