using HVLC.RentACar.Data.Abstract;
using HVLC.RentACar.Data.Concrete.EntityFramework.Contexts;
using HVLC.RentACar.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Shared.Data.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVLC.RentACar.Data.Concrete.EntityFramework.Repositories
{
    public class ReservationRepository : Repository<Reservation>, IReservationRepository
    {
        private readonly RentACarContext _context;
        public ReservationRepository(DbContext context) : base(context)
        {
            _context = new RentACarContext();
        }

        public Reservation GetLastReservationByDate()
        {
           return _context.Reservations.OrderByDescending(x=>x.CreatedDate).FirstOrDefault();
        }
    }
}
