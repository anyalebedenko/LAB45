using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NLayerApp.PL.Models
{
    public class BookingViewModel
    {

        [Key]
        public int BookingId { get; set; }
        //[Required]
        public string PersonName { get; set; }
        [Required]
        [Range (1,6)]
        public int RoomId { get; set; }
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DateIn { get; set; }
        [Required]
        [DisplayFormat(ApplyFormatInEditMode =true, DataFormatString ="{0:yyyy-MM-dd}")]
        public DateTime DateOut { get; set; }
    }
}
