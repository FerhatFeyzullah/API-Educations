using Microsoft.AspNetCore.Mvc;

namespace YummyTestProje.WebUI.ViewComponents._DefaultMenuViewComponents
{
    public class _MenuDefaultComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
