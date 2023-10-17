using MediatR;
using prmToolkit.NotificationPattern;
using VemdeZap.Domain.Commands.Group.GroupRemove.Notifications;
using VemdeZap.Domain.Interfaces.Repositories;

namespace VemdeZap.Domain.Commands.Group.GroupRemove
{
    public class GroupRemoveHandler : Notifiable, IRequestHandler<GroupRemoveRequest, Response>
    {
        private readonly IMediator _mediator;
        private readonly IRepositoryGroup _repositoryGroup;

        public GroupRemoveHandler(IMediator mediator, IRepositoryGroup repositoryGroup)
        {
            _mediator = mediator;
            _repositoryGroup = repositoryGroup;
        }

        public async Task<Response> Handle(GroupRemoveRequest request, CancellationToken cancellationToken)
        {
            //Valida se o objeto request está nulo:
            if (request == null)
            {
                AddNotification("Request", "Request é obrigatório");
                return new Response(this);
            }
            Entities.Group group = _repositoryGroup.ObterPorId(request.GroupId);
            if (group == null)
            {
                AddNotification("Group", "Grupo não existe");
                return new Response(this);
            }
            _repositoryGroup.Remover(group);
            var result = new { Id = group.Id };
            //Cria objeto de resposta:
            var response = new Response(this, result);
            //Cria e dispara notificação:
            GroupRemoveNotification notification = new GroupRemoveNotification(group);
            await _mediator.Publish(notification);
            //Retorna o resultado:
            return await Task.FromResult(response);
        }
    }
}

