namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class foreignKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Restaurants", "Manager_Id", "dbo.Employees");
            DropIndex("dbo.Restaurants", new[] { "Manager_Id" });
            AddColumn("dbo.Employees", "Restaurant_Id", c => c.Int());
            AddColumn("dbo.Reservations", "Table_Id", c => c.Int());
            AddColumn("dbo.Tables", "Employee_Id", c => c.Int());
            AddColumn("dbo.Tables", "Restaurant_Id", c => c.Int());
            CreateIndex("dbo.Employees", "Restaurant_Id");
            CreateIndex("dbo.Reservations", "Table_Id");
            CreateIndex("dbo.Tables", "Employee_Id");
            CreateIndex("dbo.Tables", "Restaurant_Id");
            AddForeignKey("dbo.Employees", "Restaurant_Id", "dbo.Restaurants", "Id");
            AddForeignKey("dbo.Tables", "Employee_Id", "dbo.Employees", "Id");
            AddForeignKey("dbo.Tables", "Restaurant_Id", "dbo.Restaurants", "Id");
            AddForeignKey("dbo.Reservations", "Table_Id", "dbo.Tables", "Id");
            DropColumn("dbo.Employees", "RestaurantId");
            DropColumn("dbo.Reservations", "TableId");
            DropColumn("dbo.Restaurants", "Manager_Id");
            DropColumn("dbo.Tables", "RestaurantId");
            DropColumn("dbo.Tables", "EmployeeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tables", "EmployeeId", c => c.Int(nullable: false));
            AddColumn("dbo.Tables", "RestaurantId", c => c.Int(nullable: false));
            AddColumn("dbo.Restaurants", "Manager_Id", c => c.Int());
            AddColumn("dbo.Reservations", "TableId", c => c.Int(nullable: false));
            AddColumn("dbo.Employees", "RestaurantId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Reservations", "Table_Id", "dbo.Tables");
            DropForeignKey("dbo.Tables", "Restaurant_Id", "dbo.Restaurants");
            DropForeignKey("dbo.Tables", "Employee_Id", "dbo.Employees");
            DropForeignKey("dbo.Employees", "Restaurant_Id", "dbo.Restaurants");
            DropIndex("dbo.Tables", new[] { "Restaurant_Id" });
            DropIndex("dbo.Tables", new[] { "Employee_Id" });
            DropIndex("dbo.Reservations", new[] { "Table_Id" });
            DropIndex("dbo.Employees", new[] { "Restaurant_Id" });
            DropColumn("dbo.Tables", "Restaurant_Id");
            DropColumn("dbo.Tables", "Employee_Id");
            DropColumn("dbo.Reservations", "Table_Id");
            DropColumn("dbo.Employees", "Restaurant_Id");
            CreateIndex("dbo.Restaurants", "Manager_Id");
            AddForeignKey("dbo.Restaurants", "Manager_Id", "dbo.Employees", "Id");
        }
    }
}
