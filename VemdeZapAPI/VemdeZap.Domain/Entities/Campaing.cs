namespace VemdeZap.Domain.Entities
{
    public class Campaing:BaseEntity
    {
        public string Name { get; set; }
        public User User { get; set; }
    }
}
