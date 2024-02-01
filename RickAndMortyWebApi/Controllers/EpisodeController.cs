using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using RickAndMortyApi.DAL.Context;
using RickAndMortyWebApi.Authentication;

namespace RickAndMortyWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EpisodeController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly string _apiKey;

        public EpisodeController(ApiContext context, IOptions<ApiSettings> apiSettings)
        {
            _context = context;
            _apiKey = apiSettings.Value.ApiKey;
        }

        [HttpGet]
        public IActionResult EpisodeList()
        {
            string clientApiKey = HttpContext.Request.Headers["X-API-Key"];
            if (string.IsNullOrEmpty(clientApiKey))
            {
                return Unauthorized("Geçersiz Key");
            }
            var values = _context.Episodes.ToList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetEpisodeById(int id)
        {
            string clientApiKey = HttpContext.Request.Headers["X-API-Key"];
            if (string.IsNullOrEmpty(clientApiKey))
            {
                return Unauthorized("Geçersiz Key");
            }
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
