using Assignment6.DTO.Franchises;
using Assignment6.Models;
using AutoMapper;

namespace Assignment6.Profiles
{
    public class FranchiseProfile : Profile
    {

        
        public FranchiseProfile()
        {
            CreateMap<FranchisePutDto, Franchise>();
            CreateMap<FranchiseCreateDTO, Franchise>();
            CreateMap<Franchise, FranchiseReadDTO>()
                .ForMember(dto => dto.Movies, opt => opt
                .MapFrom(m => m.Movies.Select(s => s.Id).ToList()));
        }
    }
}
