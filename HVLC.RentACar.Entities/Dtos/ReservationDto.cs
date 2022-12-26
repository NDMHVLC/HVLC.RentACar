using HVLC.RentACar.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVLC.RentACar.Entities.Dtos
{
    public class ReservationDto
    {
        public int Id { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public double StartingKm { get; set; }
        public double FinishKm { get; set; }
        public string Comment { get; set; }
        public DateTime? CreatedDate { get; set; }

        public int CarId { get; set; }
        public CarDto Car { get; set; }

        public ICollection<CustomerDto> Customers { get; set; }
    }
}
