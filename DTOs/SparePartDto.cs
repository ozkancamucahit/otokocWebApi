
using System.ComponentModel.DataAnnotations;

namespace otokocWebApi.Dtos;

public record SparePartDto
{
    [Required]
    public Guid Id { get; init; }

    [Required]
    public UInt64 PartNo { get; init; }

    [Required]
    public string PartName { get; init; }

    [Required]
    public string Brand { get; init; }

    [Required]
    public string Model { get; init; }

    [Required]
    public UInt16 ModelYear { get; init; }

    [Required]
    public decimal Price { get; init; }

    [Required]
    public DateTimeOffset CreatedDate {get; init;}

    [Required]
    public DateTimeOffset UpdatedDate { get; init; }

    public string ImageUrl { get; init; }


}




