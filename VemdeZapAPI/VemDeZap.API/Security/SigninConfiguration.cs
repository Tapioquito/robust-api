using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace VemDeZap.API.Security
{
    public class SigninConfiguration
    {
        private const string SECRET_KEY = "c1f51f42-5727-4d15-c6bbbb645024";
        public SigningCredentials SigningCredentials { get; set; }
        private readonly SymmetricSecurityKey _signinKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SECRET_KEY));
        public SigninConfiguration()
        {
            SigningCredentials = new SigningCredentials(_signinKey, SecurityAlgorithms.HmacSha256);
        }
    }
}
