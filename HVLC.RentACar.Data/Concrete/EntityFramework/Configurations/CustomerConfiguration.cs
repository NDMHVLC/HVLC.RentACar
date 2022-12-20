using HVLC.RentACar.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVLC.RentACar.Data.Concrete.EntityFramework.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(c => c.TcNo).IsRequired().HasMaxLength(11);
            builder.Property(c => c.Name).IsRequired().HasMaxLength(70);
            builder.Property(c => c.Surname).IsRequired().HasMaxLength(70);
            builder.Property(c => c.EMail).IsRequired().HasMaxLength(50);
            builder.Property(c => c.Password).IsRequired().HasMaxLength(25);
            builder.Property(c => c.PhoneNumber).IsRequired().HasMaxLength(13);
            builder.Property(c => c.Address).IsRequired().HasMaxLength(250);


            builder.HasOne<Reservation>(r => r.Reservation).WithMany(c => c.Customers).HasForeignKey(r => r.ReservationId);


            builder.HasData(new Customer
            {
                Id = 1,
                TcNo = 12345678910,
                Name = "Nedim",
                Surname = "HAVLACI",
                EMail = "nedimhavlaci@gmail.com",
                Password = "1234",
                PhoneNumber = "05076089730",
                Address = "Bağlarbaşı mah",
                ReservationId = 1,
                CreatedBy = 1,
                CreatedDate = DateTime.Now,


            });
        }
    }
}
