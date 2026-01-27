using AutoMapper;
using LetsFest.Data.Dto;
using LetsFest.Data.Entity;
namespace LetsFest.Web.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserProfile, UserProfileDto>()
                // Example of explicit mapping if names didn't match:
                // .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email))
                .ReverseMap(); // Allows mapping DTO back to Entity
        }
    }
}
