using Assignment6.DTO.Movies;
using Assignment6.Models;
using AutoMapper;

namespace Assignment6.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<MoviePutDTO, Movie>();
            CreateMap<MovieCreateDTO, Movie>();
            CreateMap<Movie, MovieReadDTO>()
                .ForMember(dto => dto.Characters, opt => opt
                .MapFrom(m => m.Characters.Select(s => s.Id).ToList()));
        }
    }
}
