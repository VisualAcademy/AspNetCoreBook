using System.Data.Entity;

namespace MemoEngine.Models
{
    public class ConfContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public ConfContext() : base("name=ConnectionString")
        {
        }

        public System.Data.Entity.DbSet<MemoEngine.Models.Room> Rooms { get; set; }

        public System.Data.Entity.DbSet<MemoEngine.Models.RoomSpeaker> RoomSpeakers { get; set; }
    }
}
