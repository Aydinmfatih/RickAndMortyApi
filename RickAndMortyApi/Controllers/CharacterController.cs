using Microsoft.AspNetCore.Mvc;

namespace RickAndMortyApi.Controllers
{
    public class CharacterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
