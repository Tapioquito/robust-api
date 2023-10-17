using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VemdeZap.Domain.Entities;

namespace VemDeZap.Infra.Repositories.Map
{
    public class MessageSenderMap : IEntityTypeConfiguration<MessageSender>
    {
        public void Configure(EntityTypeBuilder<MessageSender> builder)
        {
            //Nome Tabela:
            builder.ToTable("MessageSender");
            //Propriedades:
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Sent).IsRequired();

            //ForeingKey:
            builder.HasOne(x => x.Contact).WithMany().HasForeignKey("ContactId");

            builder.HasOne(x => x.Campaing).WithMany().HasForeignKey("CampaingId");

            builder.HasOne(x => x.Group).WithMany().HasForeignKey("GroupId");

        }
    }
}
