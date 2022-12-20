using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVLC.RentACar.Data.Abstract
{
    public interface IUnitOfWork
    {
        ICarRepository Cars { get; }
        ICarServiceRepository CarServicess { get; }
        ICustomerRepository Customers { get; }
        IReservationRepository Reservations { get; }

        int Save();
    }
}
