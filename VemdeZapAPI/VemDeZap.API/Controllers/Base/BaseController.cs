using Microsoft.AspNetCore.Mvc;
using VemdeZap.Domain.Commands;
using VemDeZap.Infra.Repositories.Transactions;

namespace VemDeZap.API.Controllers.Base
{
    public class BaseController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public BaseController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> ResponseAsync(Response response)
        {
            if (!response.Notifications.Any())
            {
                try
                {
                    _unitOfWork.SaveChanges();
                    return Ok(response);
                }
                catch (Exception ex)
                {
                    //Jogar o erro:
                    return BadRequest($"Houve um problema interno com o servidor. Entre em contato com o administrador. Erro: {ex.Message}");
                }
            }
            else
            {
                return Ok(response);
            }
        }
    }
}
