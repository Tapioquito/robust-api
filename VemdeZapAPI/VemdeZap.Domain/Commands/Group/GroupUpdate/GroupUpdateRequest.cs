using MediatR;
using VemdeZap.Domain.Entities.Enums;

namespace VemdeZap.Domain.Commands.Group.GroupUpdate
{
    public class GroupUpdateRequest:IRequest<Response>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public EnumTypes Type { get; set; }
        public Guid UserId { get; set; }
    }
}
