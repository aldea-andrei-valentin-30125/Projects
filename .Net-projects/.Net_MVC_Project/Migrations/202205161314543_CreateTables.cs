namespace MVCFinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTables : DbMigration
    {
        public override void Up()
        {
            /*CreateTable(
                "dbo.Carts",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    ClientId = c.String(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Clients",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    UserId = c.String(nullable: false),
                    Name = c.String(nullable: false),
                    Adress = c.String(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Deliveries",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    UserId = c.String(nullable: false),
                    Name = c.String(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Orders",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    ClientId = c.Int(nullable: false),
                    DeliveryId = c.Int(nullable: true),
                    CartId = c.Int(nullable: false),
                    CreatedAt = c.DateTime(nullable: false),
                    DeliveredAt = c.DateTime(nullable: true),
                    Status = c.Int(nullable: false)

                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.OrderItems",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    ClientId = c.Int(nullable: false),
                    ProductId = c.Int(nullable: false),

                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Produse",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    RestaurantId = c.Int(nullable: false),
                    Price = c.Int(nullable: false),
                    Name = c.String(nullable: false),

                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Restaurants",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    UserId = c.String(nullable: false),
                    Name = c.String(nullable: false),
                })
                .PrimaryKey(t => t.Id);*/


        }
        
        public override void Down()
        {
            /*DropTable("dbo.Carts");
            DropTable("dbo.Clients");
            DropTable("dbo.Deliveries");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderItems");
            DropTable("dbo.Produse");
            DropTable("dbo.Restaurants");*/
        }
    }
}
