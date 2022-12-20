using Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVLC.RentACar.Entities.Concrete
{
    public class Car : EntityBase
    {
        public double? KM { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string FuelType { get; set; }

        public int CarServiceId { get; set; }
        public CarService CarService { get; set; }

        public ICollection<Reservation> Reservations { get; set; }

    }
}
