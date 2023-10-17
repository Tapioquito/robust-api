using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VemdeZap.Domain.Entities;

namespace VemDeZap.Infra.Repositories.Map
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            //Nome Tabela:
            builder.ToTable("User");
            //Propriedades:
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FirstName).HasMaxLength(150).IsRequired();
            builder.Property(x => x.LastName).HasMaxLength(150).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Password).HasMaxLength(36).IsRequired();
            builder.Property(x => x.RegisterDate).IsRequired();
            builder.Property(x => x.isActive).IsRequired();
        }
    }
}
