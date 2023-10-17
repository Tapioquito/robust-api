namespace VemdeZap.Domain.Entities
{
    public class Campaing:BaseEntity
    {
        protected Campaing()
        {

        }
        public string Name { get; set; }
        public User User { get; set; }
    }
}
