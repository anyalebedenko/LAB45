using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using NLayerApp.DAL.Entities;
using NLayerApp.DAL.EF;
using NLayerApp.DAL.Interfaces;

namespace NLayerApp.DAL.Repositories
{
    public class BookingRepository : IRepository<Booking>
    {
        private RoomContext db;

        public BookingRepository(RoomContext context)
        {
            this.db = context;
        }

        public IEnumerable<Booking> GetAll()
        {
            return db.Bookings.Include(o => o.RoomId);
        }

        public Booking Get(int id)
        {
            return db.Bookings.Find(id);
        }

        public void Create(Booking booking)
        {
            db.Bookings.Add(booking);
        }

        public void Update(Booking booking)
        {
            db.Entry(booking).State = EntityState.Modified;
        }
        public IEnumerable<Booking> Find(Func<Booking, Boolean> predicate)
        {
            return db.Bookings.Include(o => o.RoomId).Where(predicate).ToList();
        }
        public void Delete(int id)
        {
            Booking booking = db.Bookings.Find(id);
            if (booking != null)
                db.Bookings.Remove(booking);
        }
    }
}