
using otokocWebApi.Dtos;
using otokocWebApi.Models;

namespace otokocWebApi;

public static class Extensions
{
    public static SparePartDto AsDto(this SparePart part)
    {
        return new SparePartDto
        {
            Id= part.Id,
            PartNo= part.PartNo,
            PartName= part.PartName,
            Brand= part.Brand,
            Model= part.Model,
            ModelYear= part.ModelYear,
            Price= part.Price
        };
    }
}

