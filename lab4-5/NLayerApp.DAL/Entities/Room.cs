using System;
using System.Collections.Generic;
using System.Text;

namespace NLayerApp.DAL.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public ICollection<Booking> Bookings { get; set; }
    }
}
