using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RickAndMortyApi.DAL.Context;
using RickAndMortyApi.Dtos;
using X.PagedList;

namespace RickAndMortyApi.Controllers
{
    public class CharacterController : Controller
    {
        private readonly IHttpClientFactory _client;
        private readonly ApiContext _context;

        public CharacterController(IHttpClientFactory httpClientFactory, ApiContext context)
        {
            _client = httpClientFactory;
            _context = context;
        }
        public async Task<IActionResult> Index(int page = 1)
        {
            ViewBag.t = "Karakterler";
            ViewBag.t1 = "Anasayfa";
            ViewBag.t2 = "Karakterler";
            using (var client = _client.CreateClient())
            {
                // Episode bilgilerini API'den çekme
                var characterRequest = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://localhost:7262/api/Character")
                };

                using (var episodeResponse = await client.SendAsync(characterRequest))
                {
                    episodeResponse.EnsureSuccessStatusCode();
                    var body = await episodeResponse.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<List<ResultCharacterDto>>(body).ToPagedList(page, 6);

                    return View(values);
                }
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetCharacterById(int id)
        {

            ViewBag.t = "Karakter Detayı";
            ViewBag.t1 = "Anasayfa";
            ViewBag.t2 = "Karakter Detayı";
            using (var client = _client.CreateClient())
            {
                var characterRequest = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://localhost:7262/api/Character/{id}/")
                };

                using (var value = await client.SendAsync(characterRequest))
                {
                    value.EnsureSuccessStatusCode();
                    var body = await value.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<GetCharacterByIdDto>(body);
                    return View(values);
                }
            }
        }
        [HttpPost]
        public IActionResult ToggleFavorite(int characterId)
        {
            var character = _context.Characters.FirstOrDefault(x => x.CharacterId == characterId);
            if (character != null)
            {
                if (character.IsFavorite)
                {
                    character.IsFavorite = false;
                }
                else
                {
                    var favoritedCount = _context.Characters.Count(x => x.IsFavorite);

                    if (favoritedCount < 10)
                    {
                        character.IsFavorite = true;
                    }
                    else
                    {
                        return Json(new { Success = false, Message = "Favori karakter ekleme sayısını aştınız. Başka bir karakteri favorilerden çıkarmalısınız." });
                    }
                }
                _context.SaveChanges();

                return Json(new { Success = true });

            }
            return Json(new { Success = false, Message = "Karakter bulunamadı." });
        }
        public IActionResult Search(string search)
        {
            var searchResults = _context.Characters
                .Where(e => e.Name.ToLower().Contains(search.ToLower()))
                .ToList();

            return Json(searchResults);
        }
    }
}
