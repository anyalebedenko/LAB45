using System;
using System.Collections.Generic;
using System.Text;

namespace NLayerApp.BLL.DTO //data transfer object
{
    public class RoomDTO
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
    }
}
