namespace VemdeZap.Domain.Entities
{
    public class MessageSender : BaseEntity
    {
        protected MessageSender()
        {

        }
        public Campaing Campaing { get; set; }
        public Group Group { get; set; }
        public Contact Contact { get; set; }
        public bool Sent { get; set; }
    }
}
