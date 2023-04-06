using CircusTrein.Core.Interfaces;

namespace CircusTrein.Core.Classes;

public class Herbivore : Animal, IHerbivore
{
    public override int size { get; set; }

    public Herbivore(int size)
    {
        this.size = size;
    }

    public override bool CanJoinCollection(List<IAnimal> animalList)
    {
        if (!CanBeEatenInCollection(animalList))
            return true;
        return false;
    }
}
