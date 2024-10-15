using AutoMapper;

namespace CityInfo.API.Profiles
{
    public class CityProfile : Profile
    {
        public CityProfile()
        {
            CreateMap<Entities.City, Model.CityWithoutPointOfInterestDto>();
            CreateMap<Entities.City, Model.CityDto>();
        }
    }
}
