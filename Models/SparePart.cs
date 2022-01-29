
namespace otokocWebApi.Models;


public class SparePart
{
    


    public UInt64 PartNo { get; private set; } = 0;

    public string PartName { get; private set; } = string.Empty;

    public string Brand { get; private set; } = string.Empty;

    public UInt16 Model { get; private set; }

    public UInt16 ModelYear { get; private set; }

    public UInt32 Price { get; private set; }

}


