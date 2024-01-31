namespace RickAndMortyApi.DAL.Entities
{
    public class Episode
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




