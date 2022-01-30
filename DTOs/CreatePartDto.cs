

using System.ComponentModel.DataAnnotations;

namespace otokocWebApi.Dtos;

public record CreatePartDto
{
    [Required]
     public UInt64 PartNo { get; init; }

    [Required]
    public string PartName { get; init; }
    
    [Required]
    public string Brand { get; init; }

    [Required]
    public string Model { get; init; }

    [Required]
    [Range(2005, 2023)]
    public UInt16 ModelYear { get; init; }

    [Required]
    [Range(100, 1_000_000)]
    public decimal Price { get; init; }
}





