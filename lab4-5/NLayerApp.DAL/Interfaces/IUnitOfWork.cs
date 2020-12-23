using System;
using System.Collections.Generic;
using NLayerApp.DAL.Entities;
using System.Text;

namespace NLayerApp.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Room> Rooms { get; }
        IRepository<Booking> Bookings { get; }
        void Save();
    }
}
