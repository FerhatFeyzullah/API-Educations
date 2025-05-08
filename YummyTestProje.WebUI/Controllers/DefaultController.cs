using Microsoft.AspNetCore.Mvc;

namespace YummyTestProje.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
