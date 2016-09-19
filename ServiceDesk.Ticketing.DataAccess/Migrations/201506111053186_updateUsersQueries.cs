namespace ServiceDesk.Ticketing.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateUsersQueries : DbMigration
    {
        public override void Up()
        {
            AddColumn("Ticketing.Users", "Department", c => c.String());
            DropColumn("Ticketing.Users", "Departament");
        }
        
        public override void Down()
        {
            AddColumn("Ticketing.Users", "Departament", c => c.String());
            DropColumn("Ticketing.Users", "Department");
        }
    }
}
