using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVLC.RentACar.Entities.Dtos
{
    public class CarServiceUpdateDto
    {
        public int Id { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime ReleaseDate { get; set; }

        [DisplayName("Açıklama")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        [MinLength(20, ErrorMessage = "{0} alanı {1} karakterden büyük olamaz")]
        public string Comment { get; set; }
    }
}
