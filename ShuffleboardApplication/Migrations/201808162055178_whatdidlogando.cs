namespace ShuffleboardApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class whatdidlogando : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tournaments",
                c => new
                    {
                        TournamentID = c.Int(nullable: false, identity: true),
                        DateCreated = c.DateTime(nullable: false),
                        numPlayers = c.Int(nullable: false),
                        TournamentName = c.String(),
                    })
                .PrimaryKey(t => t.TournamentID);
            
            AddColumn("dbo.Games", "Tournament_TournamentID", c => c.Int());
            CreateIndex("dbo.Games", "Tournament_TournamentID");
            AddForeignKey("dbo.Games", "Tournament_TournamentID", "dbo.Tournaments", "TournamentID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Games", "Tournament_TournamentID", "dbo.Tournaments");
            DropIndex("dbo.Games", new[] { "Tournament_TournamentID" });
            DropColumn("dbo.Games", "Tournament_TournamentID");
            DropTable("dbo.Tournaments");
        }
    }
}
