using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using NuGet.Configuration;
using RickAndMortyApi.DAL.Context;
using RickAndMortyApi.Dtos;
using RickAndMortyWebUI.Authentication;
using X.PagedList;

namespace RickAndMortyApi.Controllers
{
    public class CharacterController : Controller
    {
        private readonly IHttpClientFactory _client;
        private readonly ApiContext _context;
        private readonly string _apiKey;

        public CharacterController(ApiContext context, IOptions<ApiSettings> apiSettings, IHttpClientFactory client)
        {
            _context = context;
            _apiKey = apiSettings.Value.ApiKey;
            _client = client;
        }
        public async Task<IActionResult> Index(int page = 1)
        {
            ViewBag.t = "Karakterler";
            ViewBag.t1 = "Anasayfa";
            ViewBag.t2 = "Karakterler";
            using (var client = _client.CreateClient())
            {
                
                var characterRequest = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://localhost:7262/api/Character"),

                };
                characterRequest.Headers.Add("X-API-Key", _apiKey);


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
                characterRequest.Headers.Add("X-API-Key", _apiKey);

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
        public IActionResult ToggleFavorite(int id)
        {
            var character = _context.Characters.FirstOrDefault(x => x.CharacterId == id);
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
        [HttpGet]
        public IActionResult Favorites()
        {
            ViewBag.t = "Favori Karakterler";
            ViewBag.t1 = "Anasayfa";
            ViewBag.t2 = "Favori Karakterler";
            var values = _context.Characters.Where(x => x.IsFavorite == true).ToList();
            return View(values);

        }
        [HttpGet]
        public IActionResult DeleteCharacter(int id)
        {
            var value = _context.Characters.FirstOrDefault(x => x.CharacterId == id);
            value.IsFavorite = false;
            _context.SaveChanges();
            return RedirectToAction("Favorites");

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
