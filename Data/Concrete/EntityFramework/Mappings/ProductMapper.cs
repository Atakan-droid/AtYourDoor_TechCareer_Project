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
    public class ProductMapper : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.UnitPrice).IsRequired();
            builder.HasOne(p => p.Category).WithMany(p => p.Products).HasForeignKey(p=>p.CategoryID).OnDelete(DeleteBehavior.Cascade);
            builder.ToTable("Product");
        }
    }
}
