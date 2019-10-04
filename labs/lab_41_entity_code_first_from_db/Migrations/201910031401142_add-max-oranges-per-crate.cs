namespace lab_41_entity_code_first_from_db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmaxorangespercrate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Oranges", "MaxOrangesPerCrate", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Oranges", "MaxOrangesPerCrate");
        }
    }
}
