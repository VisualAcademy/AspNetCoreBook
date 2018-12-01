namespace MemoEngine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        RoomId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.RoomId);
            
            CreateTable(
                "dbo.Speakers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Photo = c.String(),
                        Title = c.String(),
                        Description = c.String(),
                        Room_RoomId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rooms", t => t.Room_RoomId)
                .Index(t => t.Room_RoomId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Speakers", "Room_RoomId", "dbo.Rooms");
            DropIndex("dbo.Speakers", new[] { "Room_RoomId" });
            DropTable("dbo.Speakers");
            DropTable("dbo.Rooms");
        }
    }
}
