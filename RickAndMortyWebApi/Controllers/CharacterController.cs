using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RickAndMortyApi.DAL.Context;

namespace RickAndMortyWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly ApiContext _context;

        public CharacterController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult CharacterList()
        {
            var values = _context.Characters.ToList().Take(20);
            return Ok(values);

        }

        [HttpGet("{id}")]
        public IActionResult GetCharacterById(int id)
        {
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
