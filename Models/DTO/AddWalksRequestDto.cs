using System.ComponentModel.DataAnnotations;
using TestDotnet.CustomActionFilters;

namespace TestDotnet;

public class AddWalksRequestDto
{
    [Required]
    [MaxLength(100,ErrorMessage = "max length is 100")]
    public string Name { get; set; }
    
    [Required]
    [MaxLength(1000,ErrorMessage = "max length is 1000")]
    public string Description { get; set; }
    
    [Required]
    [Range(0, 50)]
    public double LengthInKm { get; set; }
    
    public string? WalkImageUrl { get; set; }
    
    [Required]
    public Guid DifficultyID { get; set; }
    
    [Required]
    public Guid RegionId { get; set; }

}
