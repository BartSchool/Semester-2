namespace Containervervoer_Core;

public class Container
{
    public int weight { get; private set; }
    public bool isValueable { get; private set; }
    public bool isCooled { get; private set; }

    public Container(int cargoWeight)
    {
        if (cargoWeight < 0)
            throw new Exception("Can't have cargo with a negative weight");
        this.weight = cargoWeight + 4;

        isValueable = false;
        isCooled = false;
    }

    public Container(int cargoWeight, bool isValueable, bool isCooled) : this(cargoWeight)
    {
        this.isValueable = isValueable;
        this.isCooled = isCooled;
    }
}
