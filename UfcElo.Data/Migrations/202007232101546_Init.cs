namespace UfcElo.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bouts",
                c => new
                    {
                        BoutId = c.Int(nullable: false, identity: true),
                        RedFighterId = c.Int(nullable: false),
                        BlueFighterId = c.Int(nullable: false),
                        BoutDate = c.DateTime(),
                        BoutLocation = c.String(),
                        WinnerId = c.Int(nullable: false),
                        IsTitleBout = c.Boolean(nullable: false),
                        WeightClass = c.Int(nullable: false),
                        isBoutComplete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.BoutId);
            
            CreateTable(
                "dbo.Fighters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LastName = c.String(nullable: false),
                        FirstName = c.String(nullable: false),
                        Nickname = c.String(),
                        Hometown = c.String(nullable: false),
                        Wins = c.Int(nullable: false),
                        Losses = c.Int(nullable: false),
                        Draws = c.Int(nullable: false),
                        EloRating = c.Int(nullable: false),
                        IsMale = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Fighters");
            DropTable("dbo.Bouts");
        }
    }
}
