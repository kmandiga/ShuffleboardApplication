namespace ShuffleboardApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Games", "Player_PlayerID", "dbo.Players");
            DropIndex("dbo.Games", new[] { "Player_PlayerID" });
            AddColumn("dbo.Players", "gamesPlayed", c => c.Int(nullable: false));
            DropColumn("dbo.Games", "Player_PlayerID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Games", "Player_PlayerID", c => c.Int());
            DropColumn("dbo.Players", "gamesPlayed");
            CreateIndex("dbo.Games", "Player_PlayerID");
            AddForeignKey("dbo.Games", "Player_PlayerID", "dbo.Players", "PlayerID");
        }
    }
}
