using AutoMapper;
using RickAndMortyApi.DAL.Entities;
using RickAndMortyApi.Models;

namespace RickAndMortyApi.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Episode,EpisodeViewModel.Result>().ReverseMap();
        }
    }
}
