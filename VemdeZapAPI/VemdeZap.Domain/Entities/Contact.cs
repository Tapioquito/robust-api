using VemdeZap.Domain.Entities.Enums;

namespace VemdeZap.Domain.Entities
{
    public class Contact:BaseEntity
    {
        protected Contact()
        {

        }
        public string Name { get; set; }
        public string WhatsappNumber { get; set; }
        public EnumTypes Type { get; set; }
        public User User { get; set; }
    }
}
