using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VemdeZap.Domain.Commands.User.AuthenticateUser
{
    public class AuthenticateUserResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool Authenticated { get; set; }

        public static explicit operator AuthenticateUserResponse(Entities.User user)
        {
            return new AuthenticateUserResponse()
            {
                Id = user.Id,
                Name = user.FirstName,
                Authenticated = true
            };
        }
    }
}
