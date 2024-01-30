using Microsoft.AspNetCore.Mvc;

namespace RickAndMortyApi.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
