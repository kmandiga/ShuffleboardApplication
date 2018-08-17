namespace ShuffleboardApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class wewilldothat : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Players", "Tournament_TournamentID", c => c.Int());
            CreateIndex("dbo.Players", "Tournament_TournamentID");
            AddForeignKey("dbo.Players", "Tournament_TournamentID", "dbo.Tournaments", "TournamentID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Players", "Tournament_TournamentID", "dbo.Tournaments");
            DropIndex("dbo.Players", new[] { "Tournament_TournamentID" });
            DropColumn("dbo.Players", "Tournament_TournamentID");
        }
    }
}
