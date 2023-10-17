using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VemdeZap.Domain.Commands.Group.GroupRemove
{
    public class GroupRemoveRequest : IRequest<Response>
    {


        public GroupRemoveRequest(Guid id)
        {
            GroupId = id;
        }

        public Guid GroupId { get; set; }
    }
}
