namespace DateMePlease.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedIntrest : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Intrests", "InterestType_Id", "dbo.Interests");
            DropIndex("dbo.Intrests", new[] { "InterestType_Id" });
            DropIndex("dbo.Intrests", new[] { "Profile_Id" });
            AddColumn("dbo.Interests", "Profile_Id", c => c.Int());
            CreateIndex("dbo.Interests", "Profile_Id");
            DropTable("dbo.Intrests");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Intrests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InterestType_Id = c.Int(),
                        Profile_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropIndex("dbo.Interests", new[] { "Profile_Id" });
            DropColumn("dbo.Interests", "Profile_Id");
            CreateIndex("dbo.Intrests", "Profile_Id");
            CreateIndex("dbo.Intrests", "InterestType_Id");
            AddForeignKey("dbo.Intrests", "InterestType_Id", "dbo.Interests", "Id");
        }
    }
}
