using AutoMapper;
using RickAndMortyApi.DAL.Entities;
using RickAndMortyApi.Models;

namespace RickAndMortyApi.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<EpisodeViewModel.Result, Episode>().ReverseMap();
            CreateMap<CharacterViewModel.Rootobject, Character>().ReverseMap();
            CreateMap<CharacterEpisode, CharacterEpisode>().ReverseMap();
        }
    }
}
