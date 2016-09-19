namespace ServiceDesk.Ticketing.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addUsersAndCategories : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Ticketing.CategoryStates",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Ticketing.UserStates",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        SID = c.String(),
                        LoginName = c.String(),
                        DisplayName = c.String(),
                        Departament = c.String(),
                        Location = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("Ticketing.Tickets", "Priority", c => c.Int(nullable: false));
            AddColumn("Ticketing.Tickets", "Type", c => c.Int(nullable: false));
            AddColumn("Ticketing.Tickets", "DueDate", c => c.DateTime(nullable: false));
            AddColumn("Ticketing.Tickets", "ResolutionComments", c => c.String());
            AddColumn("Ticketing.Tickets", "Requestor_DisplayName", c => c.String());
            AddColumn("Ticketing.Tickets", "Requestor_Departament", c => c.String());
            AddColumn("Ticketing.Tickets", "Requestor_Location", c => c.String());
            AddColumn("Ticketing.Tickets", "AssignedTo_Id", c => c.Guid());
            AddColumn("Ticketing.Tickets", "Category_Id", c => c.Guid());
            CreateIndex("Ticketing.Tickets", "AssignedTo_Id");
            CreateIndex("Ticketing.Tickets", "Category_Id");
            AddForeignKey("Ticketing.Tickets", "AssignedTo_Id", "Ticketing.UserStates", "Id");
            AddForeignKey("Ticketing.Tickets", "Category_Id", "Ticketing.CategoryStates", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("Ticketing.Tickets", "Category_Id", "Ticketing.CategoryStates");
            DropForeignKey("Ticketing.Tickets", "AssignedTo_Id", "Ticketing.UserStates");
            DropIndex("Ticketing.Tickets", new[] { "Category_Id" });
            DropIndex("Ticketing.Tickets", new[] { "AssignedTo_Id" });
            DropColumn("Ticketing.Tickets", "Category_Id");
            DropColumn("Ticketing.Tickets", "AssignedTo_Id");
            DropColumn("Ticketing.Tickets", "Requestor_Location");
            DropColumn("Ticketing.Tickets", "Requestor_Departament");
            DropColumn("Ticketing.Tickets", "Requestor_DisplayName");
            DropColumn("Ticketing.Tickets", "ResolutionComments");
            DropColumn("Ticketing.Tickets", "DueDate");
            DropColumn("Ticketing.Tickets", "Type");
            DropColumn("Ticketing.Tickets", "Priority");
            DropTable("Ticketing.UserStates");
            DropTable("Ticketing.CategoryStates");
        }
    }
}
