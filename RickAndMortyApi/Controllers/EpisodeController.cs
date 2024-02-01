using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RickAndMortyApi.DAL.Context;
using RickAndMortyApi.DAL.Entities;
using RickAndMortyApi.Dtos;
using RickAndMortyApi.Models;
using RickAndMortyWebUI.Authentication;
using X.PagedList;

namespace RickAndMortyApi.Controllers
{
    public class EpisodeController : Controller
    {
        private readonly IHttpClientFactory _client;
        private readonly ApiContext _context;
        private readonly string _apiKey;

        public EpisodeController(ApiContext context, IOptions<ApiSettings> apiSettings, IHttpClientFactory client)
        {
            _context = context;
            _apiKey = apiSettings.Value.ApiKey;
            _client = client;
        }
        public async Task<IActionResult> Index(int page = 1)
        {
            ViewBag.t = "Bölümler";
            ViewBag.t1 = "Anasayfa";
            ViewBag.t2 = "Bölümler";
            using (var client = _client.CreateClient())
            {
                var episodeRequest = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://localhost:7262/api/Episode")
                };
                episodeRequest.Headers.Add("X-API-Key", _apiKey);
                using (var episodeResponse = await client.SendAsync(episodeRequest))
                {
                    episodeResponse.EnsureSuccessStatusCode();
                    var body = await episodeResponse.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<List<ResultEpisodeDto>>(body).ToPagedList(page, 6);

                    return View(values);
                }
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetEpisodeById(int id)
        {

            ViewBag.t = "Bölüm Detayı";
            ViewBag.t1 = "Anasayfa";
            ViewBag.t2 = "Bölüm Detayı";
            using (var client = _client.CreateClient())
            {
                var episodeRequest = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://localhost:7262/api/Episode/{id}/")
                };
                episodeRequest.Headers.Add("X-API-Key", _apiKey);

                using (var value = await client.SendAsync(episodeRequest))
                {
                    value.EnsureSuccessStatusCode();
                    var body = await value.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<GetEpisodeByIdDto>(body);
                    return View(values);
                }
            }
        }
        public IActionResult Search(string search)
        {
            var searchResults = _context.Episodes
                .Where(e => e.Name.ToLower().Contains(search.ToLower()))
                .ToList();

            return Json(searchResults);
        }

    }
}
