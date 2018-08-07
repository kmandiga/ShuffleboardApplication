namespace ShuffleboardApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class wlvrine3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Games", "mov", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Games", "mov");
        }
    }
}
