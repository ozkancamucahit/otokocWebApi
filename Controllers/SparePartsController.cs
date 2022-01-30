
using Microsoft.AspNetCore.Mvc;
using otokocWebApi.Dtos;
using otokocWebApi.Models;
using otokocWebApi.Repositories;

namespace otokocWebApi.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class SparePartsController : ControllerBase
{
    private readonly IPartsRepository Repository;

    public SparePartsController(IPartsRepository repository_)
    {
        this.Repository = repository_;
    }

    /// <summary>
    /// Returns all the spare parts.
    /// </summary>
    /// <returns>The SparePart objects in JSON form.</returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     Get /SparePart
    ///
    /// </remarks>
    [HttpGet(Name = nameof(GetParts))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IEnumerable<SparePartDto> GetParts()
    {
        var parts = Repository.GetParts().Select(part => part.AsDto() );
        return parts;
    }

    [HttpGet("{id}", Name= nameof(GetPart))]
    public ActionResult<SparePartDto> GetPart(Guid id)
    {
        var Part = Repository.GetPart(id);

        if (Part is null) return NotFound();

        return Part.AsDto();
    }

    // POST /SpareParts
    /// <summary>
    /// Creates the part.
    /// </summary>
    /// <param name="partDto">DTO to Create the Spare Part object.</param>
    /// <returns>The part object in JSON form.</returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /SpareParts
    ///
    /// </remarks>
    /// <response code="201">Returns the part in JSON form.</response>
    /// <response code="400">IF the required field is missing.</response>
    [HttpPost(Name = nameof(CreatePart))]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<SparePartDto> CreatePart(CreatePartDto partDto)
    {
        SparePart part = new()
        {
            Id= Guid.NewGuid(),
            PartNo= partDto.PartNo,
            PartName= partDto.PartName,
            Brand= partDto.Brand,
            Model= partDto.Model,
            ModelYear= partDto.ModelYear,
            Price= partDto.Price,
            CreatedDate= DateTimeOffset.UtcNow
        };
        Repository.CreatePart(part);

        return CreatedAtAction(nameof(GetPart), new {id= part.Id}, part.AsDto());
    }

    // PUT /SpareParts/{id}

    /// <summary>
    /// Updates the part with specified id.
    /// </summary>
    /// <param name="id">id of the Spare Part object to UPDATE.</param>
    /// <param name="partDto">DTO with updated DATA.</param>
    /// <returns>No Content on success.</returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     PUT /SpareParts/{id}
    ///
    /// </remarks>
    /// <response code="204">On successfull update.</response>
    /// <response code="400">IF the required field is missing.</response>
    /// <response code="404">IF the id is not found</response>
    [HttpPut("{id}", Name = nameof(UpdatePart))]
    public ActionResult UpdatePart(Guid id, UpdatePartDto partDto)
    {
        var existingPart = Repository.GetPart(id);

        if (existingPart is null) return NotFound();

        SparePart updatedPart = existingPart with {
            PartNo= partDto.PartNo,
            PartName= partDto.PartName,
            Brand= partDto.Brand,
            Model= partDto.Model,
            ModelYear= partDto.ModelYear,
            Price= partDto.Price
        };

        Repository.UpdatePart(updatedPart);
        return NoContent();
    }


    // DELETE /SpareParts/{id}

    [HttpDelete("{id}", Name = nameof(DeletePart))]
    public ActionResult DeletePart(Guid id)
    {
        var existingPart = Repository.GetPart(id);

        if (existingPart is null) return NotFound();

        Repository.DeletePart(id);
        return NoContent();
    }

}



