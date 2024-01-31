using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            using (var client = new HttpClient())
            {
                // Episode bilgilerini API'den çekme
                var episodeRequest = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://rickandmortyapi.com/api/episode")
                };

                using (var episodeResponse = await client.SendAsync(episodeRequest))
                {
                    episodeResponse.EnsureSuccessStatusCode();
                    var body = await episodeResponse.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<EpisodeViewModel.Rootobject>(body);

                    // Episode verilerini veritabanına kaydetme
                    foreach (var item in values.results)
                    {
                        var episode = new Episode
                        {
                            Name = item.name,
                            AirDate = item.air_date,
                            EpisodeCode = item.episode,
                            Url = item.url,
                            Created = item.created
                        };

                        // Bunu veritabanına ekleyin
                        _context.Episodes.Add(episode);
                        await _context.SaveChangesAsync();

                        // Character verilerini API'den çekme
                        foreach (var characterUrl in item.characters)
                        {
                            var characterResponse = await client.GetStringAsync(characterUrl);
                            var characterViewModel = JsonConvert.DeserializeObject<CharacterViewModel.Rootobject>(characterResponse);

                            var character = new Character
                            {
                                Name = characterViewModel.name,
                                Status = characterViewModel.status,
                                Species = characterViewModel.species,
                                Type = characterViewModel.type,
                                Gender = characterViewModel.gender,
                                Image = characterViewModel.image,
                                Url = characterViewModel.url,
                                Created = characterViewModel.created
                            };

                            _context.Characters.Add(character);
                            await _context.SaveChangesAsync();

                            var characterEpisode = new CharacterEpisode
                            {
                                CharacterId = character.CharacterId,
                                EpisodeId = episode.EpisodeId
                            };

                            _context.CharacterEpisodes.Add(characterEpisode);
                            await _context.SaveChangesAsync();
                        }
                    }

                    return View();
                }
            }

            //private int GetCharacterIdFromUrl(string characterUrl)
            //{
            //    if (string.IsNullOrEmpty(characterUrl))
            //    {
            //        throw new ArgumentNullException(nameof(characterUrl), "Karakter URL'si boş olamaz.");
            //    }
            //    var lastSlashIndex = characterUrl.LastIndexOf('/');
            //    var characterIdString = characterUrl.Substring(lastSlashIndex + 1);

            //    if (int.TryParse(characterIdString, out int characterId))
            //    {
            //        return characterId;
            //    }
            //    throw new InvalidOperationException("Karakter ID'si çıkartılamadı.");
            //}
        }
    }

}
