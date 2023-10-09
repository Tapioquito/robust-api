using Microsoft.EntityFrameworkCore;
using VemdeZap.Domain.Entities;

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
                optionsBuilder.UseSqlServer("Data Source=(localdb)//MSSQLLocalDB;Initial Catalog=VemDeZap;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
            }
        }

    }
}
