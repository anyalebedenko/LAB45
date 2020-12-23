using Ninject.Modules;
using NLayerApp.BLL.Services;
using NLayerApp.BLL.Interfaces;

namespace NLayerApp.PL.Util
{
    public class BookingModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IBookingService>().To<BookingService>();
        }
    }
}