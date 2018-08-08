namespace ShuffleboardApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tournamentmigration1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Games", "Player_PlayerID", "dbo.Players");
            DropIndex("dbo.Games", new[] { "Player_PlayerID" });
            CreateTable(
                "dbo.Tournaments",
                c => new
                    {
                        TournamentID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.TournamentID);
            
            DropColumn("dbo.Games", "Player_PlayerID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Games", "Player_PlayerID", c => c.Int());
            DropTable("dbo.Tournaments");
            CreateIndex("dbo.Games", "Player_PlayerID");
            AddForeignKey("dbo.Games", "Player_PlayerID", "dbo.Players", "PlayerID");
        }
    }
}
