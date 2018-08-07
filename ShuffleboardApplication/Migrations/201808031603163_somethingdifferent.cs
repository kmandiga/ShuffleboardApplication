namespace ShuffleboardApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class somethingdifferent : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Games", "Player_PlayerID", "dbo.Players");
            DropForeignKey("dbo.Games", "Player1_PlayerID", "dbo.Players");
            DropForeignKey("dbo.Games", "Player2_PlayerID", "dbo.Players");
            DropIndex("dbo.Games", new[] { "Player_PlayerID" });
            DropIndex("dbo.Games", new[] { "Player1_PlayerID" });
            DropIndex("dbo.Games", new[] { "Player2_PlayerID" });
            CreateTable(
                "dbo.PlayerGames",
                c => new
                    {
                        Player_PlayerID = c.Int(nullable: false),
                        Game_GameID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Player_PlayerID, t.Game_GameID })
                .ForeignKey("dbo.Players", t => t.Player_PlayerID, cascadeDelete: true)
                .ForeignKey("dbo.Games", t => t.Game_GameID, cascadeDelete: true)
                .Index(t => t.Player_PlayerID)
                .Index(t => t.Game_GameID);
            
            AddColumn("dbo.Games", "P1", c => c.String());
            AddColumn("dbo.Games", "P2", c => c.String());
            DropColumn("dbo.Games", "Player_PlayerID");
            DropColumn("dbo.Games", "Player1_PlayerID");
            DropColumn("dbo.Games", "Player2_PlayerID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Games", "Player2_PlayerID", c => c.Int());
            AddColumn("dbo.Games", "Player1_PlayerID", c => c.Int());
            AddColumn("dbo.Games", "Player_PlayerID", c => c.Int());
            DropForeignKey("dbo.PlayerGames", "Game_GameID", "dbo.Games");
            DropForeignKey("dbo.PlayerGames", "Player_PlayerID", "dbo.Players");
            DropIndex("dbo.PlayerGames", new[] { "Game_GameID" });
            DropIndex("dbo.PlayerGames", new[] { "Player_PlayerID" });
            DropColumn("dbo.Games", "P2");
            DropColumn("dbo.Games", "P1");
            DropTable("dbo.PlayerGames");
            CreateIndex("dbo.Games", "Player2_PlayerID");
            CreateIndex("dbo.Games", "Player1_PlayerID");
            CreateIndex("dbo.Games", "Player_PlayerID");
            AddForeignKey("dbo.Games", "Player2_PlayerID", "dbo.Players", "PlayerID");
            AddForeignKey("dbo.Games", "Player1_PlayerID", "dbo.Players", "PlayerID");
            AddForeignKey("dbo.Games", "Player_PlayerID", "dbo.Players", "PlayerID");
        }
    }
}
