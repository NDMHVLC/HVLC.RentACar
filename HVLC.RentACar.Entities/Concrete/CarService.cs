using Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVLC.RentACar.Entities.Concrete
{
    public class CarService : EntityBase
    {
        public DateTime EntryDate { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Comment { get; set; }

        public ICollection<Car> Cars { get; set; }
    }
}
