using HVLC.RentACar.Entities.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVLC.RentACar.Data.Concrete.EntityFramework.Configurations
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.Property(c => c.KM).IsRequired().HasMaxLength(7);
            builder.Property(c => c.Brand).IsRequired().HasMaxLength(50);
            builder.Property(c => c.Model).IsRequired().HasMaxLength(70);
            builder.Property(c => c.FuelType).IsRequired().HasMaxLength(50);

            builder.HasOne<CarService>(cs => cs.CarService).WithMany(c => c.Cars).HasForeignKey(cs => cs.CarServiceId);

            builder.HasData(new Car
            {
                Id = 1,
                KM = 000012,
                Brand = "Opel",
                Model = "Mokka",
                FuelType = "Benzin",
                CreatedBy = 1,
                CreatedDate = DateTime.Now.AddDays(-5),
                CarServiceId = 1,
                
            });

        }
    }
}
