namespace DateMePlease.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Demographics", "Orientation", c => c.String());
            AddColumn("dbo.Demographics", "Gender", c => c.String());
            AddColumn("dbo.Members", "MemberName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Members", "MemberName");
            DropColumn("dbo.Demographics", "Gender");
            DropColumn("dbo.Demographics", "Orientation");
        }
    }
}
