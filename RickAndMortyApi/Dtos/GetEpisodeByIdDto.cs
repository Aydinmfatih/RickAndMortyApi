using RickAndMortyApi.DAL.Entities;

namespace RickAndMortyApi.Dtos
{
    public class GetEpisodeByIdDto
    {
        public int EpisodeId { get; set; }
        public string Name { get; set; }
        public string AirDate { get; set; }
        public string EpisodeCode { get; set; }
        public string Url { get; set; }
        public DateTime Created { get; set; }
        public List<CharacterEpisode> characterEpisodes { get; set; }
    }
}
