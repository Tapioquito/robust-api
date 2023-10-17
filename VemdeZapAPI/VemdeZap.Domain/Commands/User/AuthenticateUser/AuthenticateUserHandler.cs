using MediatR;
using prmToolkit.NotificationPattern;
using VemdeZap.Domain.Extensions;
using VemdeZap.Domain.Interfaces.Repositories;


namespace VemdeZap.Domain.Commands.User.AuthenticateUser
{
    public class AuthenticateUserHandler : Notifiable, IRequestHandler<AuthenticateUserRequest, AuthenticateUserResponse>
    {
        private readonly IMediator _mediator;
        private readonly IRepositoryUser _repositoryUser;

        public AuthenticateUserHandler(IMediator mediator, IRepositoryUser repositoryUser)
        {
            _mediator = mediator;
            _repositoryUser = repositoryUser;
        }
        public async Task<AuthenticateUserResponse> Handle(AuthenticateUserRequest request, CancellationToken cancellationToken)
        {
            //Valida se o objeto request está nulo:

            if (request == null)
            {
                AddNotification("Request", "Request é obrigatório");
                return null;
            }
            request.Password = request.Password.ConvertToMD5();
            Entities.User user = _repositoryUser.ObterPor(X => X.Email == request.Email && X.Password == request.Password);
            if (user == null)
            {
                AddNotification("User", "User not found");
                return new AuthenticateUserResponse()
                {
                    Authenticated = false
                };
            }

            // AuthenticateUserResponse authResponse = new AuthenticateUserResponse();
            //Cria objeto de resposta:
            var response = (AuthenticateUserResponse)user;

            //Retorna o resultado:

            return await Task.FromResult(response);

        }

    }
     
}
