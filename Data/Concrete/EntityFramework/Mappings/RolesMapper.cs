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
    public class RolesMapper : IEntityTypeConfiguration<Roles>
    {
        public void Configure(EntityTypeBuilder<Roles> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Role).IsRequired();
            builder.HasMany(r => r.Users).WithOne(r => r.Role).HasForeignKey(r => r.RoleID);

            builder.ToTable("Roles");
            var initialRoles = new List<Roles> {
            new Roles{Id=1,Role="Admin"},
            new Roles{Id=2,Role="Tedarik Noktası Görevlisi"},
            new Roles{Id=3,Role="Kargocu"},
            new Roles{Id=4,Role="Uye"},
            };

            builder.HasData(initialRoles);
        }
    }
}
