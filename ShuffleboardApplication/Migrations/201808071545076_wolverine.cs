namespace ShuffleboardApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class wolverine : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Players", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Players", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Players", "Username", c => c.String(nullable: false, maxLength: 15));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Players", "Username", c => c.String());
            AlterColumn("dbo.Players", "LastName", c => c.String());
            AlterColumn("dbo.Players", "FirstName", c => c.String());
        }
    }
}
