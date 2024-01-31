using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RickAndMortyApi.DAL.Context;

namespace RickAndMortyWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EpisodeController : ControllerBase
    {
        private readonly ApiContext _context;

        public EpisodeController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult EpisodeList()
        {
            var values = _context.Episodes.ToList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetEpisodeById(int id)
        {
            var value = _context.Episodes
         .Include(x => x.characterEpisodes)
         .ThenInclude(y => y.Character)
         .FirstOrDefault(e => e.EpisodeId == id);

            if (value == null)
            {
                return NotFound(); 
            }

            return Ok(value);
        }
      
    }
}
