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
    public class GrouprMap : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            //Nome Tabela:
            builder.ToTable("Group");
            //Propriedades:
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(150).IsRequired();
            builder.Property(x => x.Type).IsRequired();

            //ForeingKey:
            builder.HasOne(x => x.User).WithMany().HasForeignKey("UserId");
        }
    }
}
