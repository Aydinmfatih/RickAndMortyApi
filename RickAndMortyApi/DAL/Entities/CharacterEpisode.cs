using RickAndMortyApi.Models;

namespace RickAndMortyApi.DAL.Entities
{
    public class CharacterEpisode
    {
        public int CharacterEpisodeId { get; set; }
        public int CharacterId { get; set; }
        public Character Character { get; set; }
        public int EpisodeId { get; set; }
        public Episode Episode { get; set; }
    }
}
