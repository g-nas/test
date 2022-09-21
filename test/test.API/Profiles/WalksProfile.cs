using AutoMapper;

namespace test.API.Profiles
{
    public class WalksProfile: Profile
    {
        public WalksProfile()
        {
            CreateMap<Models.Domain.Walk, Models.DTO.Walk>()
                //.ForMember(dest => dest.Id, options => options.MapFrom(src => src.IdDifferentName)); // if src and dest have different names for a property
                .ReverseMap();
            CreateMap<Models.Domain.WalkDifficulty, Models.DTO.WalkDifficulty>()
                .ReverseMap();
        }
    }
}
