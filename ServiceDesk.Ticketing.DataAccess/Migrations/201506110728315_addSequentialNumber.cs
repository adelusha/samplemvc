namespace ServiceDesk.Ticketing.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addSequentialNumber : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Ticketing.SequentialNumber",
                c => new
                    {
                        Number = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Number);
            
        }
        
        public override void Down()
        {
            DropTable("Ticketing.SequentialNumber");
        }
    }
}
