using CircusTrein.Core.Classes;

namespace CircusTrein.Core.Interfaces;

public interface IAnimal
{
    int size { get; }

    bool CanJoinCollection(IAnimalCollection animalCollection);
    public bool CanBeEatenInCollection(IAnimalCollection animalCollection);
}
