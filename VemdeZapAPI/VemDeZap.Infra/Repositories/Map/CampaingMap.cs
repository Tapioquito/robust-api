using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VemdeZap.Domain.Entities;

namespace VemDeZap.Infra.Repositories.Map
{
    public class CampaingMap : IEntityTypeConfiguration<Campaing>
    {
        public void Configure(EntityTypeBuilder<Campaing> builder)
        {
            //Nome Tabela:
            builder.ToTable("Campaing");
            //Propriedades:
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(150).IsRequired();

            builder.HasOne(x => x.User).WithMany().HasForeignKey("UserId");
        }
    }
}
