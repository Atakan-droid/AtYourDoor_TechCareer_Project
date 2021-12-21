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
    public class CountryMapper : IEntityTypeConfiguration<County>
    {
        public void Configure(EntityTypeBuilder<County> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.CountyName).IsRequired();
            builder.HasOne(c => c.City).WithMany(c => c.Counties).HasForeignKey(c => c.CityId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(c => c.Addresses).WithOne(c => c.County).HasForeignKey(c => c.CountyId).OnDelete(DeleteBehavior.NoAction); ;
            builder.ToTable("County");
        }
    }
}
