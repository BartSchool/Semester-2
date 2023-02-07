using CircusTrein.Core.Interfaces;

namespace CircusTrein.Core.Classes;

internal class AnimalCollection : IAnimalCollection
{
    public List<IAnimal> AnimalList { get; private set; }

    public AnimalCollection()
    {
        AnimalList = new();
    }

    public void AddAnimal(IAnimal animal)
    {
        AnimalList.Add(animal);
    }
}
