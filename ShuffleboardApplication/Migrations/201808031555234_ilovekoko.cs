namespace ShuffleboardApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ilovekoko : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        GameID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        P1Score = c.Int(nullable: false),
                        P2Score = c.Int(nullable: false),
                        Player_PlayerID = c.Int(),
                        Player1_PlayerID = c.Int(),
                        Player2_PlayerID = c.Int(),
                    })
                .PrimaryKey(t => t.GameID)
                .ForeignKey("dbo.Players", t => t.Player_PlayerID)
                .ForeignKey("dbo.Players", t => t.Player1_PlayerID)
                .ForeignKey("dbo.Players", t => t.Player2_PlayerID)
                .Index(t => t.Player_PlayerID)
                .Index(t => t.Player1_PlayerID)
                .Index(t => t.Player2_PlayerID);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        PlayerID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Username = c.String(),
                        gamesWon = c.Int(nullable: false),
                        CummulativePoints = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PlayerID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Games", "Player2_PlayerID", "dbo.Players");
            DropForeignKey("dbo.Games", "Player1_PlayerID", "dbo.Players");
            DropForeignKey("dbo.Games", "Player_PlayerID", "dbo.Players");
            DropIndex("dbo.Games", new[] { "Player2_PlayerID" });
            DropIndex("dbo.Games", new[] { "Player1_PlayerID" });
            DropIndex("dbo.Games", new[] { "Player_PlayerID" });
            DropTable("dbo.Players");
            DropTable("dbo.Games");
        }
    }
}
