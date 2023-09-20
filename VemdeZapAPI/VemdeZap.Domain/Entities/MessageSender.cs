using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VemdeZap.Domain.Entities
{
    public class MessageSender : BaseEntity
    {
        public Campaing Campaing { get; set; }
        public Group Group { get; set; }
        public Contact Contact { get; set; }
        public bool Sent { get; set; }
    }
}
