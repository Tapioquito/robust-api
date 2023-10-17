using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VemdeZap.Domain.Commands.Group.GroupRemove.Notifications
{
    public class GroupRemoveNotification : INotification
    {
        public GroupRemoveNotification(Entities.Group group)
        {
            Group = group;
        }

        public Entities.Group Group { get; set; }
    }
}
