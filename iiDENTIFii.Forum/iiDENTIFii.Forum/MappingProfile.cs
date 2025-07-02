using AutoMapper;
using iiDENTIFii.Forum.Dtos;
using iiDENTIFii.Forum.Models;

namespace iiDENTIFii.Forum
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Set IdentityUser Username to the e-mail address
            CreateMap<UserForRegistrationDto, User>()
                .ForMember(user => user.UserName, opt => opt.MapFrom(x => x.Email))
                .ForMember(user => user.DisplayName, opt => opt.MapFrom(x => x.DisplayName))
                .ForMember(user => user.Email, opt => opt.MapFrom(x => x.Email));
        }
    }
}