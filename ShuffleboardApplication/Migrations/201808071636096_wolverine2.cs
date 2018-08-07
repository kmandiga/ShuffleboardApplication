namespace ShuffleboardApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class wolverine2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Games", "P1", c => c.String(nullable: false));
            AlterColumn("dbo.Games", "P2", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Games", "P2", c => c.String());
            AlterColumn("dbo.Games", "P1", c => c.String());
        }
    }
}
