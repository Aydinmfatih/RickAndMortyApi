using Microsoft.AspNetCore.Mvc;

namespace RickAndMortyApi.ViewComponents
{
    public class _NavbarComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
