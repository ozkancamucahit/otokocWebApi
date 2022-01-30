

using otokocWebApi.Models;

namespace otokocWebApi.Repositories;

public interface IPartsRepository
{
    SparePart GetPart(Guid id);
    IEnumerable<SparePart> GetParts();

    void CreatePart(SparePart part);
    
    
    void UpdatePart(SparePart part);

    void DeletePart(Guid id);
}