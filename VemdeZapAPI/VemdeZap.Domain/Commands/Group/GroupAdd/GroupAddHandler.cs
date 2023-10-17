using MediatR;
using prmToolkit.NotificationPattern;
using VemdeZap.Domain.Interfaces.Repositories;

namespace VemdeZap.Domain.Commands.Group.GroupAdd
{
    public class GroupAddHandler : Notifiable, IRequestHandler<GroupAddRequest, Response>
    {
        private readonly IMediator _mediator;
        private readonly IRepositoryGroup _repositoryGroup;
        private readonly IRepositoryUser _repositoryUser;

        public GroupAddHandler(IMediator mediator, IRepositoryGroup repositoryGroup, IRepositoryUser repositoryUser)
        {
            _mediator = mediator;
            _repositoryGroup = repositoryGroup;
            _repositoryUser = repositoryUser;
        }

        public async Task<Response> Handle(GroupAddRequest request, CancellationToken cancellationToken)
        {
            //Validar se o request veio preenchido
            if (request == null)
            {
                AddNotification("Request", "Informe os dados do usuário");
                return new Response(this);
            }

            //Verificar se o grupo já existe

            var user = _repositoryUser.ObterPorId(request.UserId);
            if (user == null)
            {
                AddNotification("User", "Usuário não encontrado");
                return new Response(this);
            }
            Entities.Group group = new Entities.Group(request.Name, request.Type, user);

            AddNotifications(group); //Captura todos os erros na construção do objeto e os direciona para a API

            if (IsInvalid()) return new Response(this);

            group = _repositoryGroup.Adicionar(group);
            //Criar objeto de resposta

            var response = new Response(this, group);
            return await Task.FromResult(response);
        }
    }
}
