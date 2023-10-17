using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using VemdeZap.Domain.Commands.Group.GroupAdd;
using VemdeZap.Domain.Commands.Group.GroupList;
using VemdeZap.Domain.Commands.Group.GroupRemove;
using VemdeZap.Domain.Commands.Group.GroupUpdate;
using VemdeZap.Domain.Commands.User.AuthenticateUser;
using VemDeZap.API.Controllers.Base;
using VemDeZap.Infra.Repositories.Transactions;

namespace VemDeZap.API.Controllers
{
    [Route("api/[controller")]
    [ApiController]
    public class GroupController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GroupController(IMediator mediator, IHttpContextAccessor httpContextAccessor, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
        }

        [Authorize]
        [HttpGet]
        [Route("api/Group/List")]
        public async Task<IActionResult> ListGroup()
        {
            try
            {

                var request = new GroupListRequest();
                var result = await _mediator.Send(request, CancellationToken.None);
                return Ok(result);

            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [Authorize]
        [HttpPost]
        [Route("api/Group/Add")]
        public async Task<IActionResult> AddGroup([FromBody] GroupAddRequest request)
        {
            try
            {
                string userClaims = _httpContextAccessor.HttpContext.User.FindFirst("User").Value;
                AuthenticateUserResponse userResponse = JsonConvert.DeserializeObject<AuthenticateUserResponse>(userClaims);

                request.UserId = userResponse.Id;
                var response = await _mediator.Send(request, CancellationToken.None);
                return await ResponseAsync(response);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [Authorize]
        [HttpPut]
        [Route("api/Group/Update")]
        public async Task<IActionResult> UpdateGroup([FromBody] GroupUpdateRequest request)
        {
            try
            {
                string userClaims = _httpContextAccessor.HttpContext.User.FindFirst("User").Value;
                AuthenticateUserResponse userResponse = JsonConvert.DeserializeObject<AuthenticateUserResponse>(userClaims);

                request.UserId = userResponse.Id;
                var response = await _mediator.Send(request, CancellationToken.None);
                return await ResponseAsync(response);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpDelete]
        [Route("api/Group/Remove/{id:Guid}")]
        public async Task<IActionResult> RemoveGroup(Guid id)
        {
            try
            {
                var request = new GroupRemoveRequest(id);
                var result = await _mediator.Send(request, CancellationToken.None);
                return await ResponseAsync(result);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }



    }
}
