using HVLC.RentACar.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVLC.RentACar.Entities.Dtos
{
    public class CarDto
    {
        public int Id { get; set; }
        public double? KM { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string FuelType { get; set; }

        public int? CarServiceId { get; set; }
        public CarServiceDto CarService { get; set; }

        public ICollection<ReservationDto> Reservations { get; set; }
    }
}
