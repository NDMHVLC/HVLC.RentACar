using HVLC.RentACar.Data.Abstract;
using HVLC.RentACar.Data.Concrete.EntityFramework.Contexts;
using HVLC.RentACar.Data.Concrete.EntityFramework.Repositories;

namespace HVLC.RentACar.Data.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RentACarContext _context;

        public UnitOfWork()
        {
            _context = new RentACarContext();
        }

        private readonly CarRepository _carRepository;
        private readonly CarServiceRepository _carServiceRepository;
        private readonly CustomerRepository _customerRepository;
        private readonly ReservationRepository _reservationRepository;

        public ICarRepository Cars => _carRepository ?? new CarRepository(_context);

        public ICarServiceRepository CarServicess => _carServiceRepository?? new CarServiceRepository(_context);

        public ICustomerRepository Customers => _customerRepository?? new CustomerRepository(_context);

        public IReservationRepository Reservations => _reservationRepository?? new ReservationRepository(_context);

        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}
