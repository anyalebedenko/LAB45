using System;
using System.Collections.Generic;
using System.Text;

namespace NLayerApp.DAL.Entities
{
    public class Booking
    {
        public int BookingId { get; set; }
        public string PersonName { get; set; }
        public int RoomId { get; set; }
        public DateTime DateIn { get; set; }
        public DateTime DateOut { get; set; }
    }
}
