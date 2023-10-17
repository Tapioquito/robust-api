using Microsoft.EntityFrameworkCore;
using prmToolkit.NotificationPattern;
using VemdeZap.Domain.Entities;
using VemDeZap.Infra.Repositories.Map;

namespace VemDeZap.Infra.Repositories.Base
{
    public partial class VemDeZapContext : DbContext
    {

        //Criar Tabelas:

        public DbSet<User> User { get; set; }
        public DbSet<Campaing> Campaing { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Group> Group { get; set; }
        public DbSet<MessageSender> MessageSender { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=VemDeZap;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Ignorar classes:
            modelBuilder.Ignore<Notification>();

            //aplicar configuirações:
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new GrouprMap());
            modelBuilder.ApplyConfiguration(new ContactMap());
            modelBuilder.ApplyConfiguration(new CampaingMap());
            modelBuilder.ApplyConfiguration(new MessageSenderMap());
        }

    }
}
