using CircusTrein.Core.Interfaces;

namespace CircusTrein.Core.Classes;

public class Cart : IAnimalCollection
{
    public List<IAnimal> AnimalList { get; private set; }
    public int size { get; private set; }

    public Cart()
    {
        AnimalList = new();
        size = 10;
    }

    public int GetSpace()
    {
        int space = size;
        foreach (IAnimal animal in AnimalList)
            space -= animal.size;
        return space;
    }

    public bool CanAddAnimal(IAnimal animal)
    {
        if (GetSpace() < animal.size)
            return false;
        return true;
    }

    public bool TryAddAnimal(IAnimal animal)
    {
        if (CanAddAnimal(animal))
            if (animal.CanJoinCollection(this))
                {
                    AnimalList.Add(animal);
                    return true;
                }
        return false;
    }
    public bool TryAddAnimal(List<IAnimal> animals)
    {
        foreach (IAnimal animal in animals)
            if (!TryAddAnimal(animal))
                return false;
        return true;
    }
}
