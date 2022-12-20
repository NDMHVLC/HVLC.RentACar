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
    public class CarServiceConfiguration : IEntityTypeConfiguration<CarService>
    {
        public void Configure(EntityTypeBuilder<CarService> builder)
        {

            builder.Property(cs => cs.EntryDate).IsRequired();
            builder.Property(cs => cs.ReleaseDate).IsRequired();
            builder.Property(cs => cs.Comment).IsRequired();




            builder.HasData(new CarService
            {
                Id = 1,
                EntryDate = DateTime.Now.AddDays(7),
                ReleaseDate = DateTime.Now.AddDays(12),
                Comment = "Genel bakım yapıldı",
                CreatedBy = 1,
                CreatedDate = DateTime.Now.AddDays(13)
            });


        }
    }
}
