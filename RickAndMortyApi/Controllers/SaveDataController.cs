using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RickAndMortyApi.DAL.Context;
using RickAndMortyApi.DAL.Entities;
using RickAndMortyApi.Models;
using X.PagedList;

namespace RickAndMortyApi.Controllers
{
    public class SaveDataController : Controller
    {
        private readonly IHttpClientFactory _client;
        private readonly IMapper _mapper;
        private readonly ApiContext _context;

        public SaveDataController(IHttpClientFactory httpClientFactory, ApiContext context, IMapper mapper)
        {
            _client = httpClientFactory;
            _context = context;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            ViewBag.t = "Bölümler";
            ViewBag.t1 = "Anasayfa";
            ViewBag.t2 = "Bölümler";

            var client = _client.CreateClient();


            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://rickandmortyapi.com/api/episode")
            };
            using (var response = await client.SendAsync(request))
            {

                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<EpisodeViewModel.Rootobject>(body);

                //foreach (var item in values.results)
                //{
                //    var episode = new Episode
                //    {
                //        Name = item.name,
                //        AirDate = item.air_date,
                //        EpisodeCode = item.episode,
                //        Url = item.url,
                //        Created = item.created
                //    };
                //    _context.Episodes.Add(episode);
                //}
                //await _context.SaveChangesAsync();
                var values1 = _context.Episodes.ToList().ToPagedList(page, 6);
                return View(values1);

            }
        }

        public async Task<IActionResult> GetCharacters(int id)
        {
            var client = _client.CreateClient();


            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://rickandmortyapi.com/api/character")
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<EpisodeViewModel.Rootobject>(body);

                return View(values);

            }
        }

    }
}
