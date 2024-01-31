using static RickAndMortyApi.Models.CharacterViewModel;

namespace RickAndMortyApi.DAL.Entities
{
    public class Character
    {
        public int CharacterId { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Species { get; set; }
        public string Type { get; set; }
        public string? Gender { get; set; }
        public string Image { get; set; }
        public string Url { get; set; }
        public DateTime Created { get; set; }
        public bool IsFavorite { get; set; }

        public List<CharacterEpisode> characterEpisodes { get; set; }
    }
}




