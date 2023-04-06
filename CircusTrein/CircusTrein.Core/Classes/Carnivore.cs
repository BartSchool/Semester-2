using CircusTrein.Core.Interfaces;

namespace CircusTrein.Core.Classes;

public class Carnivore : Animal, ICarnivore
{
    public override int size { get; set; }

    public Carnivore(int size)
    {
        this.size = size;
    }

    public bool CanEat(IAnimal animal)
    {
        if (animal.size <= size)
            return true;
        return false;
    }

    public override bool CanJoinCollection(List<IAnimal> animalList)
    {
        if (!CanBeEatenInCollection(animalList))
        {
            foreach (IAnimal animal in animalList)
                if (CanEat(animal))
                    return false;
            return true;
        }
        return false;
    }
}
