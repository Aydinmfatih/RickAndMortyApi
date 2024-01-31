using Microsoft.AspNetCore.Mvc;
using RickAndMortyApi.DAL.Context;

namespace RickAndMortyApi.ViewComponents
{
    public class _FactsComponentPartial:ViewComponent
    {
        private readonly ApiContext _context;

        public _FactsComponentPartial(ApiContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.characters= _context.Characters.Count();
            ViewBag.episodes= _context.Episodes.Count();
            return View();
        }
    }
}
