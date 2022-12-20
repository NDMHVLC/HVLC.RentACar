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
    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.Property(r => r.RentalDate).IsRequired();
            builder.Property(r => r.DeliveryDate).IsRequired();
            builder.Property(r => r.StartingKm).IsRequired().HasMaxLength(7);
            builder.Property(r => r.FinishKm).IsRequired().HasMaxLength(7);
            builder.Property(r => r.Comment).IsRequired();


            builder.HasOne<Car>(r => r.Car).WithMany(c => c.Reservations).HasForeignKey(r => r.CarId);


            builder.HasData(new Reservation
            {
                Id = 1,
                RentalDate = DateTime.Now,
                DeliveryDate = DateTime.Now.AddDays(5),
                StartingKm = 001235,
                FinishKm = 001265,
                Comment = "Rahat ve komforlu bir araçtı",
                CarId = 1,
                CreatedBy = 1,
                CreatedDate = DateTime.Now.AddDays(6),
            });
        }
    }
}
