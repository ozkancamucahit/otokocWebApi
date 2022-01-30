
using otokocWebApi.Models;

namespace otokocWebApi.Repositories;

public class InMemPartsRepository : IPartsRepository
{
    private readonly List<SparePart> Parts = new()
    {
        new SparePart
        {
            Id = Guid.NewGuid(),
            PartNo = 1,
            PartName = "lol",
            Brand = "Volvo",
            Model = "XC40",
            ModelYear = 2022,
            Price = 2200.15m,
            CreatedDate= DateTimeOffset.UtcNow
        },
        new SparePart
        {
            Id = Guid.NewGuid(),
            PartNo = 2,
            PartName = "lol",
            Brand = "Volvo",
            Model = "XC40",
            ModelYear = 2020,
            Price = 2000.15m,
            CreatedDate= DateTimeOffset.UtcNow
        },
        new SparePart
        {
            Id = Guid.NewGuid(),
            PartNo = 3,
            PartName = "lol",
            Brand = "Volvo",
            Model = "XC90",
            ModelYear = 2022,
            Price = 4400.15m,
            CreatedDate= DateTimeOffset.UtcNow
        },
    };

    public async Task<IEnumerable<SparePart>> GetPartsAsync()
    {
        return await Task.FromResult(Parts);
    }

    public async Task<SparePart> GetPartAsync(Guid id)
    {
        var part = Parts.Where(part => part.Id == id).SingleOrDefault();

        //if ( part is null) return null;

        return await Task.FromResult(part);
    }

    public async Task CreatePartAsync(SparePart part)
    {
        Parts.Add(part);
        await Task.CompletedTask;
    }


    public async Task UpdatePartAsync(SparePart part)
    {
        var index = Parts.FindIndex(existingPart => existingPart.Id == part.Id);

        Parts[index] = part;
        await Task.CompletedTask;
    }


    public async Task DeletePartAsync(Guid id)
    {
        var index = Parts.FindIndex(existingPart => existingPart.Id == id);

        Parts.RemoveAt(index);
        await Task.CompletedTask;
    }







}

