
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
    private readonly IPartsRepository repository;

    public SparePartsController(IPartsRepository repository_)
    {
        this.repository = repository_;
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
        var parts = repository.GetParts().Select(part => part.AsDto() );
        return parts;
    }

    [HttpGet("{id}", Name= nameof(GetPart))]
    public ActionResult<SparePartDto> GetPart(Guid id)
    {
        var Part = repository.GetPart(id);

        if (Part is null) return NotFound();

        return Part.AsDto();
    }



}



