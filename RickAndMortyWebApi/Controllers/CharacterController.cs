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
    public class CharacterController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly string _apiKey;

        public CharacterController(ApiContext context, IOptions<ApiSettings> apiSettings)
        {
            _context = context;
            _apiKey = apiSettings.Value.ApiKey;
        }

        [HttpGet]
        public IActionResult CharacterList()
        {
            string clientApiKey = HttpContext.Request.Headers["X-API-Key"];
            if (string.IsNullOrEmpty(clientApiKey))
            {
                return Unauthorized("Geçersiz Key");
            }
            var values = _context.Characters.ToList().Take(20);
            return Ok(values);

        }


        [HttpGet("{id}")]
        public IActionResult GetCharacterById(int id)
        {
            string clientApiKey = HttpContext.Request.Headers["X-API-Key"];
            if (string.IsNullOrEmpty(clientApiKey))
            {
                return Unauthorized("Geçersiz Key");
            }
            var value = _context.Characters
         .FirstOrDefault(e => e.CharacterId == id);

            if (value == null)
            {
                return NotFound();
            }
            return Ok(value);
        }
    }
}
