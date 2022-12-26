using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVLC.RentACar.Entities.Dtos
{
    public class CustomerAddDto
    {
        [DisplayName("TC No")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        public double? TcNo { get; set; }

        [DisplayName("Ad")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        [MaxLength(60, ErrorMessage = "{0} alanı {1} karakterden büyük olamaz")]
        [MinLength(2, ErrorMessage = "{0} alanı {1} karakterden büyük olamaz")]
        public string Name { get; set; }

        [DisplayName("Soyad")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        [MaxLength(80, ErrorMessage = "{0} alanı {1} karakterden büyük olamaz")]
        [MinLength(2, ErrorMessage = "{0} alanı {1} karakterden büyük olamaz")]
        public string Surname { get; set; }

        [DisplayName("Mail")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        [MaxLength(50, ErrorMessage = "{0} alanı {1} karakterden büyük olamaz")]
        [MinLength(2, ErrorMessage = "{0} alanı {1} karakterden büyük olamaz")]
        public string EMail { get; set; }

        [DisplayName("Parola")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        [MaxLength(30, ErrorMessage = "{0} alanı {1} karakterden büyük olamaz")]
        [MinLength(5, ErrorMessage = "{0} alanı {1} karakterden büyük olamaz")]
        public string Password { get; set; }

        [DisplayName("Telefon Numarası")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        [MaxLength(14, ErrorMessage = "{0} alanı {1} karakterden büyük olamaz")]
        public string PhoneNumber { get; set; }

        [DisplayName("Adres")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        [MaxLength(350, ErrorMessage = "{0} alanı {1} karakterden büyük olamaz")]
        [MinLength(2, ErrorMessage = "{0} alanı {1} karakterden büyük olamaz")]
        public string Address { get; set; }


        [DisplayName("Rezervasyon ")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        public int ReservationId { get; set; }
    }
}
