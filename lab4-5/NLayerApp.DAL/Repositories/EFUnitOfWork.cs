using System;
using NLayerApp.DAL.EF;
using NLayerApp.DAL.Interfaces;
using NLayerApp.DAL.Entities;

namespace NLayerApp.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private RoomContext db;
        private RoomRepository roomRepository;
        private BookingRepository bookingRepository;

        public EFUnitOfWork(string connectionString)
        {
            db = new RoomContext(connectionString);
        }
        public IRepository<Room> Rooms
        {
            get
            {
                if (roomRepository == null)
                    roomRepository = new RoomRepository(db);
                return roomRepository;
            }
        }

        public IRepository<Booking> Bookings
        {
            get
            {
                if (bookingRepository == null)
                    bookingRepository = new BookingRepository(db);
                return bookingRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}