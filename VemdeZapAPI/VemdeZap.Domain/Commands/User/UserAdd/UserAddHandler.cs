using MediatR;
using prmToolkit.NotificationPattern;
using VemdeZap.Domain.Interfaces.Repositories;

namespace VemdeZap.Domain.Commands.User.UserAdd
{
    public class UserAddHandler : Notifiable, IRequestHandler<UserAddRequest, Response>
    {
        private readonly IMediator _mediator;
        private readonly IRepositoryUser _repositoryUser;

        public UserAddHandler(IMediator mediator, IRepositoryUser repositoryUser)
        {
            _mediator = mediator;
            _repositoryUser = repositoryUser;
        }

        public async Task<Response> Handle(UserAddRequest request, CancellationToken cancellationToken)
        {
            //Validar se o request veio preenchido
            if (request == null)
            {
                AddNotification("Request", "Informe os dados do usuário");
                return new Response(this);
            }

            //Verificar se o usuário já existe
            if (_repositoryUser.Existe(u => u.Email == request.Email))
            {
                AddNotification("Email", "Este e-mail já está em uso");
                return new Response(this);
            }
            Entities.User user = new Entities.User(request.FirstName, request.LastName, request.Email, request.Password);

            AddNotifications(user); //Captura todos os erros na construção do objeto e os direciona para a API

            if (IsInvalid()) return new Response(this);

            user = _repositoryUser.Adicionar(user);




            //Criar objeto de resposta

            var response = new Response(this, user);

            UserAddNotification addUserNotification = new UserAddNotification(user);

            await _mediator.Publish(addUserNotification);

            return await Task.FromResult(response);
        }
    }
}
