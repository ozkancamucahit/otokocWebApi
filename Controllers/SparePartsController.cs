
using Microsoft.AspNetCore.Mvc;
using otokocWebApi.Dtos;
using otokocWebApi.Models;
using otokocWebApi.Repositories;
using System.Net.Mime;

namespace otokocWebApi.Controllers;

[ApiController]
[Route("[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Consumes(MediaTypeNames.Application.Json)]
public class SparePartsController : ControllerBase
{
    private readonly IPartsRepository Repository;

    public SparePartsController(IPartsRepository repository_)
    {
        this.Repository = repository_;
    }

    //  GET all parts
    /// <summary>
    /// Returns all the spare parts.
    /// </summary>
    /// <returns>The SparePart objects in JSON form.</returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     Get /SpareParts
    ///
    /// </remarks>
    /// <response code="200">Returns parts in JSON form.</response>
    /// <response code="404">IF the list is empty.</response>
    /// TODO: add fromquery to limit requests.
    [HttpGet(Name = nameof(GetPartsAsync))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IEnumerable<SparePartDto>>> GetPartsAsync()
    {
        var parts = (await Repository.GetPartsAsync())
                    .Select(part => part.AsDto() );
        if (!parts.Any()) return NotFound();
        
        return Ok(parts);
    }

    // GET part
    /// <summary>
    /// Returns the part with the specified id.
    /// </summary>
    /// <param name="id">id to look for.</param>
    /// <returns>THe part in JSON form.</returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET /SpareParts/{id}
    ///
    /// </remarks>
    /// <response code="200">Returns the part in JSON form.</response>
    /// <response code="404">IF the id is not found.</response>
    [HttpGet("{id}", Name= nameof(GetPartAsync))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<SparePartDto>> GetPartAsync(Guid id)
    {
        var Part = await Repository.GetPartAsync(id);

        if (Part is null) return NotFound();

        return Ok(Part.AsDto());
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
    ///     POST /SpareParts/{part}
    ///
    /// </remarks>
    /// <response code="201">Returns the part in JSON form.</response>
    /// <response code="400">IF the required field is missing.</response>
    [HttpPost(Name = nameof(CreatePartAsync))]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<SparePartDto>> CreatePartAsync(CreatePartDto partDto)
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
            CreatedDate= DateTimeOffset.UtcNow,
            UpdatedDate= DateTimeOffset.UtcNow,
            ImageUrl= partDto.ImageUrl
        };
        await Repository.CreatePartAsync(part);

        return CreatedAtAction(nameof(GetPartAsync), new {id= part.Id}, part.AsDto());
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
    /// TODO: add JSON Patch package to patch properties.
    [HttpPut("{id}", Name = nameof(UpdatePartAsync))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> UpdatePartAsync(Guid id, UpdatePartDto partDto)
    {
        var existingPart = await Repository.GetPartAsync(id);

        if (existingPart is null) return NotFound();

        SparePart updatedPart = existingPart with {
            PartNo= partDto.PartNo,
            PartName= partDto.PartName,
            Brand= partDto.Brand,
            Model= partDto.Model,
            ModelYear= partDto.ModelYear,
            Price= partDto.Price,
            UpdatedDate= DateTimeOffset.UtcNow,
            ImageUrl = partDto.ImageUrl
        };

        await Repository.UpdatePartAsync(updatedPart);
        return NoContent();
    }


    // DELETE /SpareParts/{id}

    /// <summary>
    /// DELETES the part with specified id.
    /// </summary>
    /// <param name="id">id of the Spare Part object to DELETE.</param>
    /// <returns>No Content on success.</returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     DELETE /SpareParts/{id}
    ///
    /// </remarks>
    /// <response code="204">On successfull delete.</response>
    /// <response code="404">IF the id is not found</response>
    [HttpDelete("{id}", Name = nameof(DeletePartAsync))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeletePartAsync(Guid id)
    {
        var existingPart = await Repository.GetPartAsync(id);

        if (existingPart is null) return NotFound();

        await Repository.DeletePartAsync(id);
        return NoContent();
    }

}



