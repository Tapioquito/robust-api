using prmToolkit.NotificationPattern;

namespace VemdeZap.Domain.Entities
{
    public abstract class BaseEntity : Notifiable
    {
        public Guid Id { get; set; }
        protected BaseEntity()
        {
            Id = Guid.NewGuid();
        }
    }
}
