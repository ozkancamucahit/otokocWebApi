
using otokocWebApi.Dtos;
using otokocWebApi.Models;

namespace otokocWebApi;

public static class Extensions
{
    /// <summary>
    /// Converts SparePart to DTO
    /// </summary>
    /// <param name="part">Part to convert.</param>
    /// <returns>SparePartDto Object</returns>
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
            Price= part.Price,
            CreatedDate= part.CreatedDate,
            UpdatedDate= part.UpdatedDate,
            ImageUrl = part.ImageUrl
        };
    }
}

