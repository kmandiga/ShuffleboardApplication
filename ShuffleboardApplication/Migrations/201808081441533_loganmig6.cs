namespace ShuffleboardApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class loganmig6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Games", "Player_PlayerID", c => c.Int());
            CreateIndex("dbo.Games", "Player_PlayerID");
            AddForeignKey("dbo.Games", "Player_PlayerID", "dbo.Players", "PlayerID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Games", "Player_PlayerID", "dbo.Players");
            DropIndex("dbo.Games", new[] { "Player_PlayerID" });
            DropColumn("dbo.Games", "Player_PlayerID");
        }
    }
}
