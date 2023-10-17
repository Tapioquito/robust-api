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
    public class ContactMap : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            //Nome Tabela:
            builder.ToTable("Contact");
            //Propriedades:
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(150).IsRequired();
            builder.Property(x => x.WhatsappNumber).HasMaxLength(150).IsRequired();
            builder.Property(x => x.Type).HasMaxLength(100).IsRequired();

            //ForeingKey:
            builder.HasOne(x => x.User).WithMany().HasForeignKey("UserId");
        }
    }
}
