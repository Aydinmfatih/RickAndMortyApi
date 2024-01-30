using Microsoft.AspNetCore.Mvc;

namespace RickAndMortyApi.ViewComponents
{
    public class _FactsComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
