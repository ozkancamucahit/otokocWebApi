
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

    public IEnumerable<SparePart> GetParts()
    {
        return Parts;
    }

    public SparePart GetPart(Guid id)
    {
        SparePart? res = Parts.Where(part => part.Id == id).SingleOrDefault();

        //if ( res is null) return null;

        return res;
    }

    public void CreatePart(SparePart part)
    {
        Parts.Add(part);
    }


    public void UpdatePart(SparePart part)
    {
        var index = Parts.FindIndex(existingPart => existingPart.Id == part.Id);

        Parts[index] = part;
    }


    public void DeletePart(Guid id)
    {
        var index = Parts.FindIndex(existingPart => existingPart.Id == id);

        Parts.RemoveAt(index);
    }







}

