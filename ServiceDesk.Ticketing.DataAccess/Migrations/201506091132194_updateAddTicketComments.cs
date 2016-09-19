namespace ServiceDesk.Ticketing.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateAddTicketComments : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Ticketing.TicketCommentStates",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Comment = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        TicketState_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Ticketing.Tickets", t => t.TicketState_Id)
                .Index(t => t.TicketState_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Ticketing.TicketCommentStates", "TicketState_Id", "Ticketing.Tickets");
            DropIndex("Ticketing.TicketCommentStates", new[] { "TicketState_Id" });
            DropTable("Ticketing.TicketCommentStates");
        }
    }
}
