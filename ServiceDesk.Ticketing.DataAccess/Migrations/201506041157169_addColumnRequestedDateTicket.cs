namespace ServiceDesk.Ticketing.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addColumnRequestedDateTicket : DbMigration
    {
        public override void Up()
        {
            AddColumn("Ticketing.Tickets", "RequestedDate", c => c.DateTime(nullable: false));
            AlterColumn("Ticketing.Tickets", "DueDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("Ticketing.Tickets", "DueDate", c => c.DateTime(nullable: false));
            DropColumn("Ticketing.Tickets", "RequestedDate");
        }
    }
}
