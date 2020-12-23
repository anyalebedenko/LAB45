using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace NLayerApp.PL.Models
{
        public class RoomContext : DbContext
        {
            public DbSet<RoomViewModel> Rooms { get; set; }
    }
}