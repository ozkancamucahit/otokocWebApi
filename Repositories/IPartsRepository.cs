

using otokocWebApi.Models;

namespace otokocWebApi.Repositories;

public interface IPartsRepository
{
    SparePart GetPart(Guid id);
    IEnumerable<SparePart> GetParts();
}