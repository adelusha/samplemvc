namespace ServiceDesk.Ticketing.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateUsersAndCategoriesTableNames : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "Ticketing.CategoryStates", newName: "Categories");
            RenameTable(name: "Ticketing.UserStates", newName: "Users");
        }
        
        public override void Down()
        {
            RenameTable(name: "Ticketing.Users", newName: "UserStates");
            RenameTable(name: "Ticketing.Categories", newName: "CategoryStates");
        }
    }
}
