namespace ShuffleboardApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class wlvrne4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Games", "margin", c => c.Int(nullable: false));
            DropColumn("dbo.Games", "mov");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Games", "mov", c => c.Int(nullable: false));
            DropColumn("dbo.Games", "margin");
        }
    }
}
