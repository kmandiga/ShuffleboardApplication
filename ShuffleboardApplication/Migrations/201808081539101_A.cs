namespace ShuffleboardApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class A : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Tournaments");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Tournaments",
                c => new
                    {
                        TournamentID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.TournamentID);
            
        }
    }
}
