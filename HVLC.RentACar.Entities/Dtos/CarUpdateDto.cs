using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVLC.RentACar.Entities.Dtos
{
    public class CarUpdateDto
    {

        public int Id { get; set; }

        [DisplayName("Km")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        public double? KM { get; set; }


        [DisplayName("Marka")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        [MaxLength(50, ErrorMessage = "{0} alanı {1} karakterden büyük olamaz")]
        [MinLength(2, ErrorMessage = "{0} alanı {1} karakterden büyük olamaz")]
        public string Brand { get; set; }


        [DisplayName("Model")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        [MaxLength(70, ErrorMessage = "{0} alanı {1} karakterden büyük olamaz")]
        [MinLength(2, ErrorMessage = "{0} alanı {1} karakterden küçük olamaz")]
        public string Model { get; set; }


        [DisplayName("Yakıt Tipi")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        [MaxLength(50, ErrorMessage = "{0} alanı {1} karakterden küçük olamaz")]
        [MinLength(2, ErrorMessage = "{0} alanı {1} karakterden küçük olamaz")]
        public string FuelType { get; set; }


        [DisplayName("Araba Servis")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        public int CarServiceId { get; set; }

    }
}
