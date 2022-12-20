using HVLC.RentACar.Data.Concrete.EntityFramework.Configurations;
using HVLC.RentACar.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVLC.RentACar.Data.Concrete.EntityFramework.Contexts
{
    public class RentACarContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarService> CarServices { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Reservation> Reservations { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=NED\SQLEXPRESS ;Database=HVLCRentACarDB ; Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CarConfiguration());
            modelBuilder.ApplyConfiguration(new CarServiceConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new ReservationConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
