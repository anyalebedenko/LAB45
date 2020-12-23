using NLayerApp.BLL.DTO;
using System.Collections.Generic;
namespace NLayerApp.BLL.Interfaces
{
    public interface IBookingService
    {
        void MakeBooking(BookingDTO bookingDto);
        RoomDTO GetRoom(int? id);
        IEnumerable<RoomDTO> GetRooms();
        void Dispose();
    }
}