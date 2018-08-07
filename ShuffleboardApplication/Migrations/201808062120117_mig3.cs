namespace ShuffleboardApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Games", "P1_PlayerID", "dbo.Players");
            DropForeignKey("dbo.Games", "P2_PlayerID", "dbo.Players");
            DropIndex("dbo.Games", new[] { "P1_PlayerID" });
            DropIndex("dbo.Games", new[] { "P2_PlayerID" });
            AddColumn("dbo.Games", "P1", c => c.String());
            AddColumn("dbo.Games", "P2", c => c.String());
            DropColumn("dbo.Games", "P1_PlayerID");
            DropColumn("dbo.Games", "P2_PlayerID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Games", "P2_PlayerID", c => c.Int());
            AddColumn("dbo.Games", "P1_PlayerID", c => c.Int());
            DropColumn("dbo.Games", "P2");
            DropColumn("dbo.Games", "P1");
            CreateIndex("dbo.Games", "P2_PlayerID");
            CreateIndex("dbo.Games", "P1_PlayerID");
            AddForeignKey("dbo.Games", "P2_PlayerID", "dbo.Players", "PlayerID");
            AddForeignKey("dbo.Games", "P1_PlayerID", "dbo.Players", "PlayerID");
        }
    }
}
