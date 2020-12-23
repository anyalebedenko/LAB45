using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using NLayerApp.DAL.Entities;

namespace NLayerApp.DAL.EF
{
    public class RoomContext : DbContext
    {
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        static RoomContext()
        {
            Database.SetInitializer<RoomContext>(new StoreDbInitializer());
        }
        public RoomContext(string connectionString)
            : base(connectionString)
        {
        }
    }

    public class StoreDbInitializer : DropCreateDatabaseIfModelChanges<RoomContext>
    {
        protected override void Seed(RoomContext db)
        {
            db.Rooms.Add(new Room { Id = 1, Category = "Econom", Price = 400, Count = 12});
            db.Rooms.Add(new Room { Id = 2, Category = "Standart", Price = 600, Count = 8 });
            db.Rooms.Add(new Room { Id = 3, Category = "Standard+", Price = 800, Count = 5 });
            db.Rooms.Add(new Room { Id = 4, Category = "Comfort", Price = 1200, Count = 3 });
            db.Rooms.Add(new Room { Id = 5, Category = "Lux", Price = 1800, Count = 9 });
            db.Rooms.Add(new Room { Id = 6, Category = "President", Price = 2500, Count = 2 });
            db.SaveChanges();
        }
    }
}