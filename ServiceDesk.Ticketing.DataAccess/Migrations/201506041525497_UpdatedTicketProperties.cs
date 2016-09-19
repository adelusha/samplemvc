namespace ServiceDesk.Ticketing.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedTicketProperties : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Ticketing.Tasks",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TaskNumber = c.Int(nullable: false),
                        Title = c.String(),
                        Description = c.String(),
                        CreatedDateTime = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        AssignedTo_Id = c.Guid(),
                        TicketState_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Ticketing.Users", t => t.AssignedTo_Id)
                .ForeignKey("Ticketing.Tickets", t => t.TicketState_Id)
                .Index(t => t.AssignedTo_Id)
                .Index(t => t.TicketState_Id);
            
            AddColumn("Ticketing.Tickets", "TicketNumber", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("Ticketing.Tasks", "TicketState_Id", "Ticketing.Tickets");
            DropForeignKey("Ticketing.Tasks", "AssignedTo_Id", "Ticketing.Users");
            DropIndex("Ticketing.Tasks", new[] { "TicketState_Id" });
            DropIndex("Ticketing.Tasks", new[] { "AssignedTo_Id" });
            DropColumn("Ticketing.Tickets", "TicketNumber");
            DropTable("Ticketing.Tasks");
        }
    }
}
