using CityInfo.API.Model;

namespace CityInfo.API
{
    public class CitiesDataStore
    {
        public List<CityDto> Cities { get; set; }

        //public static CitiesDataStore Current { get; } = new CitiesDataStore();

        public CitiesDataStore()
        {
            Cities = new List<CityDto>()
            {
                new CityDto()
                {
                    Id = 1,
                    Name = "New York City",
                    Description = "The one with that big park",
                    PointOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id = 1,
                            Name = "Central Park",
                            Description = "The most visited urban park"
                        },
                        new PointOfInterestDto()
                        {
                            Id = 2,
                            Name = "Empire State Building",
                            Description = "A 102-story skyscraper"
                        }
                    }
                },
                new CityDto() {
                    Id = 2,
                    Name = "Antwerp",
                    Description = "The with the cathedral",
                    PointOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id = 3,
                            Name = "The Cathedral",
                            Description = "Not Finish"
                        },
                        new PointOfInterestDto()
                        {
                            Id = 4,
                            Name = "Central Station",
                            Description = "Finest example of railway architecture"
                        }
                    }
                },
                new CityDto()
                {
                    Id = 3,
                    Name = "Paris",
                    Description = "The one with big tower",
                    PointOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id = 5,
                            Name = "Eiffel Tower",
                            Description = "A wrought iron lattice"
                        },
                        new PointOfInterestDto()
                        {
                            Id = 6,
                            Name = "The Lourve",
                            Description = "The world's largest museus"
                        }
                    }
                }
            };
        }
    }
}
