using System.ComponentModel.DataAnnotations;

namespace CityInfo.API.Model
{
    public class PointOfInterestForUpdateDto
    {
        [Required(ErrorMessage = "Name is required!")]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(200)]
        public string? Description { get; set; }
    }
}
