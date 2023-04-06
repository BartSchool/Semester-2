using CircusTrein.Core.Classes;

namespace CircusTrein.Core.Interfaces;

public interface IAnimal
{
    int size { get; }

    public bool CanBeEatenInCollection(List<IAnimal> animalList);
    public bool CanJoinCollection(List<IAnimal> animalList);
}
