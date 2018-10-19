namespace DateMePlease.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateIntrestAndIntrestType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InterestTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Interests", "InterestType_Id", c => c.Int());
            CreateIndex("dbo.Interests", "InterestType_Id");
            AddForeignKey("dbo.Interests", "InterestType_Id", "dbo.InterestTypes", "Id");
            DropColumn("dbo.Interests", "Name");
            DropColumn("dbo.Interests", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Interests", "Description", c => c.String());
            AddColumn("dbo.Interests", "Name", c => c.String());
            DropForeignKey("dbo.Interests", "InterestType_Id", "dbo.InterestTypes");
            DropIndex("dbo.Interests", new[] { "InterestType_Id" });
            DropColumn("dbo.Interests", "InterestType_Id");
            DropTable("dbo.InterestTypes");
        }
    }
}
