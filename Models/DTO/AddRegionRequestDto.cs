using System.ComponentModel.DataAnnotations;
using TestDotnet.CustomActionFilters;

namespace TestDotnet;

public class AddRegionRequestDto
{
    [Required]
    [MinLength(3, ErrorMessage = "Code Should Have 3 Letter")]
    [MaxLength(3, ErrorMessage = "Code Should Have 3 Letter")]
    public string Code { get; set; }
    
    [Required]
    [MaxLength(100, ErrorMessage = "Name Should Have Maximum 100 Letter")]
    public string Name { get; set; }
    
    public string? RegionImageUrl { get; set; }
}
