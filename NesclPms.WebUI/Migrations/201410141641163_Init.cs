namespace NesclPms.WebUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "LabelName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "LabelName");
        }
    }
}
