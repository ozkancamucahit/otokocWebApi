

using otokocWebApi.Models;

namespace otokocWebApi.Repositories;

public interface IPartsRepository
{
    Task<SparePart> GetPartAsync(Guid id);
    Task<IEnumerable<SparePart>> GetPartsAsync();

    Task CreatePartAsync(SparePart part);
    
    
    Task UpdatePartAsync(SparePart part);

    Task DeletePartAsync(Guid id);
}