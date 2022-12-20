using HVLC.RentACar.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVLC.RentACar.Entities.Dtos
{
    public class CarServiceDto
    {
        public int Id { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Comment { get; set; }

        public ICollection<CarDto> Cars { get; set; }
    }
}
