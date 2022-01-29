
using Microsoft.AspNetCore.Mvc;
using otokocWebApi.Models;
using otokocWebApi.Repositories;

namespace otokocWebApi.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class SparePartController : ControllerBase
{
    private readonly InMemPartsRepository repository;

    public SparePartController()
    {
        repository = new InMemPartsRepository();
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
    public IEnumerable<SparePart> GetParts()
    {
        var parts = repository.GetParts();
        return parts;
    }

    [HttpGet("{id}", Name= nameof(GetPart))]
    public ActionResult<SparePart> GetPart(Guid id)
    {
        var Part = repository.GetPart(id);

        if (Part is null) return NotFound();

        return Part;
    }



}



