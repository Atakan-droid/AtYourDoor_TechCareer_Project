using AuthManager.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Concrete.EntityFramework.Mappings
{
    public class AddressMapper : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(a => a.Id);
            builder.HasOne(a => a.County).WithMany(a => a.Addresses).HasForeignKey(a=>a.CountyId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(a => a.User).WithMany(a => a.Address).HasForeignKey(U => U.UserId);
            builder.Property(a => a.Description).IsRequired();
            builder.ToTable("Addresses");
        }
    }
}
