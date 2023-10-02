using MediatR;

namespace VemdeZap.Domain.Commands.User.UserAdd
{
    public class UserAddRequest : IRequest<Response>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
