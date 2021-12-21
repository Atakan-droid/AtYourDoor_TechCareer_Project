using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Concrete.EntityFramework.Context
{
    internal class CategoryMapper : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasMany(c => c.Products).WithOne(c => c.Category).HasForeignKey(c => c.CategoryID).OnDelete(DeleteBehavior.Cascade);
            builder.Property(c=>c.Name).IsRequired();
            builder.ToTable("Category");
        }
    }
}