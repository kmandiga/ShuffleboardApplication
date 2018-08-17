namespace ShuffleboardApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tournamentdatabaseupdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Players", "Tournament_TournamentID", "dbo.Tournaments");
            DropIndex("dbo.Players", new[] { "Tournament_TournamentID" });
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
            
            CreateTable(
                "dbo.TournamentPlayers",
                c => new
                    {
                        Tournament_TournamentID = c.Int(nullable: false),
                        Player_PlayerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tournament_TournamentID, t.Player_PlayerID })
                .ForeignKey("dbo.Tournaments", t => t.Tournament_TournamentID, cascadeDelete: true)
                .ForeignKey("dbo.Players", t => t.Player_PlayerID, cascadeDelete: true)
                .Index(t => t.Tournament_TournamentID)
                .Index(t => t.Player_PlayerID);
            
            DropColumn("dbo.Players", "Tournament_TournamentID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Players", "Tournament_TournamentID", c => c.Int());
            DropForeignKey("dbo.TournamentPlayers", "Player_PlayerID", "dbo.Players");
            DropForeignKey("dbo.TournamentPlayers", "Tournament_TournamentID", "dbo.Tournaments");
            DropForeignKey("dbo.PlayerGames", "Game_GameID", "dbo.Games");
            DropForeignKey("dbo.PlayerGames", "Player_PlayerID", "dbo.Players");
            DropIndex("dbo.TournamentPlayers", new[] { "Player_PlayerID" });
            DropIndex("dbo.TournamentPlayers", new[] { "Tournament_TournamentID" });
            DropIndex("dbo.PlayerGames", new[] { "Game_GameID" });
            DropIndex("dbo.PlayerGames", new[] { "Player_PlayerID" });
            DropTable("dbo.TournamentPlayers");
            DropTable("dbo.PlayerGames");
            CreateIndex("dbo.Players", "Tournament_TournamentID");
            AddForeignKey("dbo.Players", "Tournament_TournamentID", "dbo.Tournaments", "TournamentID");
        }
    }
}
