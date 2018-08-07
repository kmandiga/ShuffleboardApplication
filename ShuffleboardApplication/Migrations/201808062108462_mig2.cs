namespace ShuffleboardApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PlayerGames", "Player_PlayerID", "dbo.Players");
            DropForeignKey("dbo.PlayerGames", "Game_GameID", "dbo.Games");
            DropIndex("dbo.PlayerGames", new[] { "Player_PlayerID" });
            DropIndex("dbo.PlayerGames", new[] { "Game_GameID" });
            AddColumn("dbo.Games", "Player_PlayerID", c => c.Int());
            AddColumn("dbo.Games", "P1_PlayerID", c => c.Int());
            AddColumn("dbo.Games", "P2_PlayerID", c => c.Int());
            CreateIndex("dbo.Games", "Player_PlayerID");
            CreateIndex("dbo.Games", "P1_PlayerID");
            CreateIndex("dbo.Games", "P2_PlayerID");
            AddForeignKey("dbo.Games", "Player_PlayerID", "dbo.Players", "PlayerID");
            AddForeignKey("dbo.Games", "P1_PlayerID", "dbo.Players", "PlayerID");
            AddForeignKey("dbo.Games", "P2_PlayerID", "dbo.Players", "PlayerID");
            DropColumn("dbo.Games", "P1");
            DropColumn("dbo.Games", "P2");
            DropTable("dbo.PlayerGames");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PlayerGames",
                c => new
                    {
                        Player_PlayerID = c.Int(nullable: false),
                        Game_GameID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Player_PlayerID, t.Game_GameID });
            
            AddColumn("dbo.Games", "P2", c => c.String());
            AddColumn("dbo.Games", "P1", c => c.String());
            DropForeignKey("dbo.Games", "P2_PlayerID", "dbo.Players");
            DropForeignKey("dbo.Games", "P1_PlayerID", "dbo.Players");
            DropForeignKey("dbo.Games", "Player_PlayerID", "dbo.Players");
            DropIndex("dbo.Games", new[] { "P2_PlayerID" });
            DropIndex("dbo.Games", new[] { "P1_PlayerID" });
            DropIndex("dbo.Games", new[] { "Player_PlayerID" });
            DropColumn("dbo.Games", "P2_PlayerID");
            DropColumn("dbo.Games", "P1_PlayerID");
            DropColumn("dbo.Games", "Player_PlayerID");
            CreateIndex("dbo.PlayerGames", "Game_GameID");
            CreateIndex("dbo.PlayerGames", "Player_PlayerID");
            AddForeignKey("dbo.PlayerGames", "Game_GameID", "dbo.Games", "GameID", cascadeDelete: true);
            AddForeignKey("dbo.PlayerGames", "Player_PlayerID", "dbo.Players", "PlayerID", cascadeDelete: true);
        }
    }
}
