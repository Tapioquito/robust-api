using VemdeZap.Domain.Entities.Enums;

namespace VemdeZap.Domain.Entities
{
    public class Group:BaseEntity
    {
        public string Name { get; set; }
        public EnumTypes Type { get; set; }
        public User User { get; set; }
    }
}
