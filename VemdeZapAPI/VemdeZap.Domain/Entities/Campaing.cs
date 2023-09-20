using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VemdeZap.Domain.Entities
{
    public class Campaing:BaseEntity
    {
        public string Name { get; set; }
        public User User { get; set; }
    }
}
