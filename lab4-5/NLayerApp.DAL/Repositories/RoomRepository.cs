﻿using System;
using System.Collections.Generic;
using System.Linq;
using NLayerApp.DAL.Entities;
using NLayerApp.DAL.EF;
using NLayerApp.DAL.Interfaces;
using System.Data.Entity;
 
namespace NLayerApp.DAL.Repositories
{
    public class RoomRepository : IRepository<Room>
    {
        private RoomContext db;
 
        public RoomRepository(RoomContext context)
        {
            this.db = context;
        }
 
        public IEnumerable<Room> GetAll()
        {
            return db.Rooms;
        }
 
        public Room Get(int id)
        {
            return db.Rooms.Find(id);
        }
 
        public void Create(Room room)
        {
            db.Rooms.Add(room);
        }
 
        public void Update(Room room)
        {
            db.Entry(room).State = EntityState.Modified;
        }
 
        public IEnumerable<Room> Find(Func<Room, Boolean> predicate)
        {
            return db.Rooms.Where(predicate).ToList();
        }
 
        public void Delete(int id)
        {
            Room room = db.Rooms.Find(id);
            if (room != null)
                db.Rooms.Remove(room);
        }
    }
}