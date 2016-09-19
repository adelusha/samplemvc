namespace ServiceDesk.Ticketing.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Ticketing.Tickets",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Description = c.String(),
                        Title = c.String(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("Ticketing.Tickets");
        }
    }
}
