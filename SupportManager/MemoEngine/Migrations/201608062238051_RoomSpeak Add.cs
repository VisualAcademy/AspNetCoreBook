namespace MemoEngine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RoomSpeakAdd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Speakers", "Room_RoomId", "dbo.Rooms");
            DropIndex("dbo.Speakers", new[] { "Room_RoomId" });
            CreateTable(
                "dbo.RoomSpeakers",
                c => new
                    {
                        RoomSpeakerId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        RoomId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RoomSpeakerId)
                .ForeignKey("dbo.Rooms", t => t.RoomId, cascadeDelete: true)
                .Index(t => t.RoomId);
            
            DropTable("dbo.Speakers");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.RoomSpeakers", "RoomId", "dbo.Rooms");
            DropIndex("dbo.RoomSpeakers", new[] { "RoomId" });
            DropTable("dbo.RoomSpeakers");
            CreateIndex("dbo.Speakers", "Room_RoomId");
            AddForeignKey("dbo.Speakers", "Room_RoomId", "dbo.Rooms", "RoomId");
        }
    }
}
