using AuthManager.Entities;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Concrete.EntityFramework.Mappings
{
    public class CityMapper : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.CityName).IsRequired();
            builder.HasMany(c => c.Counties).WithOne(c => c.City).HasForeignKey(c => c.CityId).OnDelete(DeleteBehavior.NoAction);
            builder.ToTable("City");
        }
    }
}
