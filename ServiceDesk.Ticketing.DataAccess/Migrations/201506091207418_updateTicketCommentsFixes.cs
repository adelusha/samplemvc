namespace ServiceDesk.Ticketing.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateTicketCommentsFixes : DbMigration
    {
        public override void Up()
        {
            AddColumn("Ticketing.TicketComments", "User_Id", c => c.Guid());
            CreateIndex("Ticketing.TicketComments", "User_Id");
            AddForeignKey("Ticketing.TicketComments", "User_Id", "Ticketing.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("Ticketing.TicketComments", "User_Id", "Ticketing.Users");
            DropIndex("Ticketing.TicketComments", new[] { "User_Id" });
            DropColumn("Ticketing.TicketComments", "User_Id");
        }
    }
}
