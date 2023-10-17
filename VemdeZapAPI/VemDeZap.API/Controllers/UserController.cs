using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using VemdeZap.Domain.Commands.User.AuthenticateUser;
using VemdeZap.Domain.Commands.User.UserAdd;
using VemDeZap.API.Controllers.Base;
using VemDeZap.API.Security;
using VemDeZap.Infra.Repositories.Transactions;

namespace VemDeZap.API.Controllers
{
    
    public class UserController : BaseController
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/User/add")]
        public async Task<IActionResult> Add([FromBody] UserAddRequest request)
        {
            try
            {
                var response = await _mediator.Send(request, CancellationToken.None);
                return await ResponseAsync(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [AllowAnonymous]
        [HttpPost]
        [Route("api/User/Authenticate")]
        public async Task<IActionResult> AuthenticateUser(

            [FromBody] AuthenticateUserRequest request
            ,
            [FromServices] SigninConfiguration singinConfiguration,
            [FromServices] TokenConfiguration tokenConfiguration
            )
        {
            try
            {
                var authenticateUserResponse = await _mediator.Send(request, CancellationToken.None);
                if ((authenticateUserResponse.Authenticated == true)
                    {
                    var response = GenerateToken(authenticateUserResponse, singinConfiguration, tokenConfiguration);
                    return Ok(response);
                }
                return Ok(authenticateUserResponse);

            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }



        }
        private object GenerateToken(AuthenticateUserResponse response, SigninConfiguration signinConfiguration, TokenConfiguration tokenConfiguration)
        {
            if (response.Authenticated == true)
            {
                ClaimsIdentity identity = new ClaimsIdentity(
                    new GenericIdentity(response.Id.ToString(), "Id"),
                    new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim("User",JsonConvert.SerializeObject(response))
                    }
                    );
                DateTime creationDate = DateTime.Now;
                DateTime expirationDate = creationDate + TimeSpan.FromSeconds(tokenConfiguration.Seconds);

                var handler = new JwtSecurityTokenHandler();
                var securityTOken = handler.CreateToken(new Microsoft.IdentityModel.Tokens.SecurityTokenDescriptor
                {
                    Issuer = tokenConfiguration.Issuer,
                    Audience = tokenConfiguration.Audience,
                    SigningCredentials = signinConfiguration.SigningCredentials,
                    Subject = identity,
                    NotBefore = creationDate,
                    Expires = expirationDate
                });
            }
            else
            {
                return response;
            }
        }

    }
}
