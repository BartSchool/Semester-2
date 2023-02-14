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

    public void AddAnimal(IAnimal animal)
    {
        if (animal.CanJoinCart(this))
            AnimalList.Add(animal);
    }

    public int GetCarnivoreSize()
    {
        int result = 0;
        foreach (Carnivore carnivore in AnimalList.OfType<Carnivore>())
            if (carnivore.size > result)
                result = carnivore.size;
        return result;
    }
}
