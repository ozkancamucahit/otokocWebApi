
namespace otokocWebApi.Models;


public record SparePart
{
    
    public Guid Id { get; init; }

    public UInt64 PartNo { get; init; }

    public string PartName { get; init; }

    public string Brand { get; init; }

    public string Model { get; init; }

    public UInt16 ModelYear { get; init; }

    public decimal Price { get; init; }

    public DateTimeOffset CreatedDate {get; init;}

    public DateTimeOffset UpdatedDate { get; init; }

    /// <summary>
    /// Image url stored in the cloud.
    /// </summary>
    public string ImageUrl { get; init; }

}


