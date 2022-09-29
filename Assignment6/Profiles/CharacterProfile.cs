using Assignment6.DTO.Characters;
using Assignment6.Models;
using AutoMapper;

namespace Assignment6.Profiles
{
    public class CharacterProfile : Profile
    {
        public CharacterProfile()
        {
            CreateMap<CharacterPutDTO, Character>();
            CreateMap<CharacterCreateDTO, Character>();
            CreateMap<Character, CharacterReadDTO>()
                .ForMember(dto => dto.Movies, opt => opt
                .MapFrom(m => m.Movies.Select(s => s.Id).ToList()));   
        }
    }
}
