using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVLC.RentACar.Entities.Dtos
{
    public class ReservationUpdateDto
    {
        public int Id { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime DeliveryDate { get; set; }

        [DisplayName("Başlangıç Km")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        public double StartingKm { get; set; }

        [DisplayName("Bitiş Km")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        public double FinishKm { get; set; }

        [DisplayName("Açıklama")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        [MinLength(20, ErrorMessage = "{0} alanı {1} karakterden küçük olamaz")]
        public string Comment { get; set; }


        [DisplayName("Araba ")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        public int CarId { get; set; }
    }
}
