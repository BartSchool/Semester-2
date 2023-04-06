using CircusTrein.Core.Interfaces;

namespace CircusTrein.Core.Classes;

public class Omnivore : Animal, ICarnivore, IHerbivore
{
    public override int size { get; set; }

    public Omnivore(int size)
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
