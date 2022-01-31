
namespace otokocWebApi.Dtos;

public record SparePartDto
{
    
    public Guid Id { get; init; }

    public UInt64 PartNo { get; init; } = 0;

    public string PartName { get; init; } = string.Empty;

    public string Brand { get; init; } = string.Empty;

    public string Model { get; init; } = string.Empty;

    public UInt16 ModelYear { get; init; }

    public decimal Price { get; init; }

    public string ImageUrl { get; init; } = string.Empty;


}




