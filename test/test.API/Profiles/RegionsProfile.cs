using AutoMapper;

namespace test.API.Profiles
{
    public class RegionsProfile: Profile
    {
        public RegionsProfile()
        {
            CreateMap<Models.Domain.Region, Models.DTO.Region>()
                //.ForMember(dest => dest.Id, options => options.MapFrom(src => src.IdDifferentName)); // if src and dest have different names for a property
                .ReverseMap();
        }
    }
}
