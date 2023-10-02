using Microsoft.AspNetCore.Mvc;

namespace VemDeZap.API.Controllers
{
    public class TestController : Controller
    {
        public string Get()
        {
            return "1.0.0";
        }
    }
}
