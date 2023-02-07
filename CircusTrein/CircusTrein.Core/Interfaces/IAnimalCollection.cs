using CircusTrein.Core.Classes;

namespace CircusTrein.Core.Interfaces;

public interface IAnimalCollection
{
    List<IAnimal> AnimalList { get; }

    void AddAnimal(IAnimal animal);
}
