using Microsoft.AspNetCore.Mvc;

namespace RickAndMortyApi.ViewComponents
{
    public class _TopbarComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
