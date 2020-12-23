using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NLayerApp.PL.Models;
using System.Data;
using System.Web.Http.Description;

namespace NLayerApp.PL.Controllers
{
    public class ValuesBookingController : ApiController
    {
        BookingContext db;

        public ValuesBookingController()
        {
            db = new BookingContext();
        }
        [HttpGet]
        [ResponseType(typeof(IEnumerable<BookingViewModel>))]
        public IHttpActionResult GetBookings()
        {
            return Ok(db.Bookings);
        }
        [HttpGet]
        [ResponseType(typeof(BookingViewModel))]
        public IHttpActionResult GetBookings(int id)
        {
            BookingViewModel booking = db.Bookings.Find(id);
            return Ok(booking);
        }

        [HttpPost]
        [ResponseType(typeof(BookingViewModel))]
        public IHttpActionResult PostBookings( BookingViewModel booking)
        {
            db.Bookings.Add(booking);
            db.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = booking.BookingId }, booking);
        }

        [HttpPut]
        [ResponseType(typeof(BookingViewModel))]
        public IHttpActionResult PutBookings(int id,  BookingViewModel booking)
        {
            if (id !=0)
            {
                db.Entry(booking).State = EntityState.Modified;

                db.SaveChanges();
                return Ok();
            }
            return NotFound();
        }
        [HttpDelete]
        [ResponseType(typeof(BookingViewModel))]
        public IHttpActionResult DeleteBookings(int id)
        {
            if (id != 0)
            {
                var book = db.Bookings.FirstOrDefault(i => i.BookingId == id);
                db.Bookings.Remove(book);
                db.SaveChanges();
                return Ok();
            }
            else { return NotFound(); }
        }
    }
}
