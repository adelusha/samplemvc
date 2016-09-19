namespace ServiceDesk.Ticketing.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateTicketCommentsTableName : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "Ticketing.TicketCommentStates", newName: "TicketComments");
        }
        
        public override void Down()
        {
            RenameTable(name: "Ticketing.TicketComments", newName: "TicketCommentStates");
        }
    }
}
