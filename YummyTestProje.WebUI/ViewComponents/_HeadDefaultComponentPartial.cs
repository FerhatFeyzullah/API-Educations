using Microsoft.AspNetCore.Mvc;

namespace YummyTestProje.WebUI.ViewComponents
{
    public class _HeadDefaultComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
