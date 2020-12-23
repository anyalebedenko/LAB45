using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NLayerApp.PL.Models;
using System.Data;

namespace NLayerApp.PL.Controllers
{
    public class ValuesControllerRooms : ApiController
    {
        RoomContext db = new RoomContext();

        public IEnumerable<RoomViewModel> GetRooms()
        {
            return db.Rooms;
        }

        public RoomViewModel GetRoom(int id)
        {
            RoomViewModel room = db.Rooms.Find(id);
            return room;
        }

        [HttpPost]
        public void CreateRoom([FromBody] RoomViewModel room)
        {
            db.Rooms.Add(room);
            db.SaveChanges();
        }

        [HttpPut]
        public void EditRoom(int id, [FromBody] RoomViewModel room)
        {
            if (id == room.Id)
            {
                db.Entry(room).State = EntityState.Modified;

                db.SaveChanges();
            }
        }

        public void DeleteRoom(int id)
        {
            RoomViewModel room = db.Rooms.Find(id);
            if (room != null)
            {
                db.Rooms.Remove(room);
                db.SaveChanges();
            }
        }
    }
}
