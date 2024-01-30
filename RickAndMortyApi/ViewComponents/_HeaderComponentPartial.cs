using Microsoft.AspNetCore.Mvc;

namespace RickAndMortyApi.ViewComponents
{
    public class _HeaderComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
