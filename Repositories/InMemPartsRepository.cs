
using otokocWebApi.Models;

namespace otokocWebApi.Repositories;

public class InMemPartsRepository
{
    private readonly List<SparePart> Parts = new()
    {
        new SparePart { Id= Guid.NewGuid(), PartNo= 1, PartName="lol",
        Brand="Volvo", Model="XC40", ModelYear=2022, Price=2200.15m},
        new SparePart { Id= Guid.NewGuid(), PartNo= 1, PartName="lol",
        Brand="Volvo", Model="XC40", ModelYear=2020, Price=2000.15m},
        new SparePart { Id= Guid.NewGuid(), PartNo= 1, PartName="lol",
        Brand="Volvo", Model="XC90", ModelYear=2022, Price=4400.15m},
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


}

