using MediatR;
using prmToolkit.NotificationPattern;
using VemdeZap.Domain.Interfaces.Repositories;

namespace VemdeZap.Domain.Commands.Group.GroupList
{
    public class GroupListHandler : Notifiable, IRequestHandler<GroupListRequest, Response>
    {
        private readonly IMediator _mediator;
        private readonly IRepositoryGroup _repositoryGroup;

        public GroupListHandler(IMediator mediator, IRepositoryGroup repositoryGroup)
        {
            _mediator = mediator;
            _repositoryGroup = repositoryGroup;
        }

        public async Task<Response> Handle(GroupListRequest request, CancellationToken cancellationToken)
        {
            //Validar se o objeto request está nulo
            if (request == null)
            {
                AddNotification("Request", "Request é obrigatório");
                return new Response(this);
            }
            var groupCollection = _repositoryGroup.Listar().ToList();

            //Criar objeto de resposta:
            var response = new Response(this, groupCollection);
            //Retorna o resultado:
            return await Task.FromResult(response);
        }
    }
}
