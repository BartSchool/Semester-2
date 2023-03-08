using CircusTrein.Core.Classes;

namespace CircusTrein.Core.Interfaces;

public interface IAnimalCollection
{
    List<IAnimal> AnimalList { get; }

    bool TryAddAnimal(IAnimal animal);
    bool TryAddAnimal(List<IAnimal> animals);
}
