using Microsoft.AspNetCore.Mvc;

namespace YummyTestProje.WebUI.ViewComponents
{
    public class _AboutDefaultComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
    
}
