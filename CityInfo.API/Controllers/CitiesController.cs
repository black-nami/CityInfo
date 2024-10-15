using AutoMapper;
using CityInfo.API.Model;
using CityInfo.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/cities")]
    public class CitiesController: ControllerBase
    {
        //private readonly CitiesDataStore _citiesDataStore;
        private readonly ICityInfoRepository _cityInfoRepository;
        private readonly IMapper _mapper;

        public CitiesController(ICityInfoRepository cityInfoRepository, IMapper mapper)
        {
            _cityInfoRepository = cityInfoRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CityWithoutPointOfInterestDto>>> GetCities()
        {
            var cityEntities = await _cityInfoRepository.GetCitiesAsync();

            return Ok(_mapper.Map<IEnumerable<CityWithoutPointOfInterestDto>>(cityEntities));

            //var results = new List<CityWithoutPointOfInterestDto>();

            //foreach (var cityEntity in cityEntities)
            //{
            //    results.Add(new CityWithoutPointOfInterestDto
            //    {
            //        Id = cityEntity.Id,
            //        Description = cityEntity.Description,
            //        Name = cityEntity.Name
            //    });
            //}

            //return Ok(results);
            //return Ok(_citiesDataStore.Cities);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCity(int id, bool includePointOfInterest)
        {
            var city = await _cityInfoRepository.GetCitiesAsync(id, includePointOfInterest);

            if (city == null)
            {
                return NotFound();
            }

            if (includePointOfInterest)
            {
                return Ok(_mapper.Map<CityDto>(city));
            }

            return Ok(_mapper.Map<CityWithoutPointOfInterestDto>(city));
        }
    }
}
