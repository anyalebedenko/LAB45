using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NLayerApp.BLL.Interfaces;
using NLayerApp.BLL.DTO;
using NLayerApp.PL.Models;
using AutoMapper;
using NLayerApp.BLL.Infrastructure;

namespace NLayerApp.PL.Controllers
{
    public class HomeController : Controller
    {
        IBookingService bookingService;
        public HomeController(IBookingService serv)
        {
            bookingService = serv;
        }
        public ActionResult Index()
        {
            IEnumerable<RoomDTO> roomDtos = bookingService.GetRooms();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<RoomDTO, RoomViewModel>()).CreateMapper();
            var rooms = mapper.Map<IEnumerable<RoomDTO>, List<RoomViewModel>>(roomDtos);
            return View(rooms);
        }

        public ActionResult MakeBooking(int? id)
        {

            try
            {
                RoomDTO room = bookingService.GetRoom(id);
                var booking = new BookingViewModel { RoomId = room.Id };

                return View(booking);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult MakeBooking(BookingViewModel booking)
        {
            try
            {
                var bookingDTO = new BookingDTO { BookingId = booking.BookingId, PersonName = booking.PersonName, RoomId = booking.RoomId, DateIn = booking.DateIn, DateOut = booking.DateOut};
                bookingService.MakeBooking(bookingDTO);
                return Content("<h2>Номер успешно забронирован :)</h2>");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View(booking);
        }
        protected override void Dispose(bool disposing)
        {
            bookingService.Dispose();
            base.Dispose(disposing);
        }
    }
}