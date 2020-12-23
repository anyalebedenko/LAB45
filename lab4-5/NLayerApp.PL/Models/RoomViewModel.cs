using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayerApp.PL.Models
{
    public class RoomViewModel
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
    }
}
