using Microsoft.AspNetCore.Mvc;

namespace RickAndMortyApi.ViewComponents
{
    public class _PageTitleComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
