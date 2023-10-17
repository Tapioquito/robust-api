using MediatR;
using prmToolkit.NotificationPattern;
using VemdeZap.Domain.Interfaces.Repositories;

namespace VemdeZap.Domain.Commands.Group.GroupUpdate
{
    public class GroupUpdateHandler : Notifiable, IRequestHandler<GroupUpdateRequest, Response>
    {

        private readonly IMediator _mediator;
        private readonly IRepositoryGroup _repositoryGroup;
        private readonly IRepositoryUser _repositoryUser;

        public GroupUpdateHandler(IMediator mediator, IRepositoryGroup repositoryGroup, IRepositoryUser repositoryUser)
        {
            _mediator = mediator;
            _repositoryGroup = repositoryGroup;
            _repositoryUser = repositoryUser;
        }

        public async Task<Response> Handle(GroupUpdateRequest request, CancellationToken cancellationToken)
        {
            //Validar se o request veio preenchido
            if (request == null)
            {
                AddNotification("Request", "Informe os dados do grupo");
                return new Response(this);
            }

            //Verificar se o grupo já existe

            var user = _repositoryUser.ObterPorId(request.Id);
            if (user == null)
            {
                AddNotification("User", "Usuário não encontrado");
                return new Response(this);
            }
            Entities.Group group = _repositoryGroup.ObterPorId(request.Id);

            group.UpdateGroup(request.Name, request.Type);

            if (group == null)
            {
                AddNotification("Group", "Grupo não encontrado");
                return new Response(this);
            }

            group = _repositoryGroup.Editar(group);
            var result = new { Id = group.Id, Name = group.Name, Type = group.Type };
            //Criar objeto de resposta

            var response = new Response(this, result);
            return await Task.FromResult(response);
        }
    }
}
