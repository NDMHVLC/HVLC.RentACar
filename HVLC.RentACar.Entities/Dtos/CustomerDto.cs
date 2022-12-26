using HVLC.RentACar.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVLC.RentACar.Entities.Dtos
{
    public class CustomerDto
    {

        public int Id { get; set; }
        public double? TCNo { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string EMail { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }


        public int ReservationId { get; set; }
        public ReservationDto Reservation { get; set; }
    }
}
