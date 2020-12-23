using System;
using NLayerApp.BLL.DTO;
using NLayerApp.DAL.Entities;
using NLayerApp.BLL.BusinessModels;
using NLayerApp.DAL.Interfaces;
using NLayerApp.BLL.Infrastructure;
using NLayerApp.BLL.Interfaces;
using System.Collections.Generic;
using AutoMapper;

namespace NLayerApp.BLL.Services
{
    public class BookingService : IBookingService
    {
        IUnitOfWork Database { get; set; }

        public BookingService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public void MakeBooking(BookingDTO bookingDto)
        {
            Room room = Database.Rooms.Get(bookingDto.RoomId);

            // валидация
            if (room == null)
                throw new ValidationException("Такого номера нет", "");
            // применяем SpecialOffer  
            //decimal price = new Discount(1).GetDiscountedPrice(booking.TotalPrice);
            Booking booking = new Booking
            {
                BookingId = bookingDto.BookingId,
                PersonName = bookingDto.PersonName,
                RoomId = bookingDto.RoomId,
                DateIn = bookingDto.DateIn,
                DateOut = bookingDto.DateOut               
            };

            Database.Bookings.Create(booking);
            Database.Save();
        }

        public IEnumerable<RoomDTO> GetRooms()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Room, RoomDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Room>, List<RoomDTO>>(Database.Rooms.GetAll());
        }

        public RoomDTO GetRoom(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id номера", "");
            var room = Database.Rooms.Get(id.Value);
            if (room == null)
                throw new ValidationException("Такого номера нет", "");

            return new RoomDTO { Id = room.Id, Category = room.Category, Price = room.Price, Count = room.Count };
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
