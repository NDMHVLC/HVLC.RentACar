using Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVLC.RentACar.Entities.Concrete
{
    public class Reservation : EntityBase
    {
        public DateTime RentalDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public double StartingKm { get; set; }
        public double FinishKm { get; set; }
        public string Comment { get; set; }

        public int CarId { get; set; }
        public Car Car { get; set; }

        public ICollection<Customer> Customers { get; set; }

    }
}
