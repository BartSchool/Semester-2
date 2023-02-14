using CircusTrein.Core.Interfaces;

namespace CircusTrein.Core.Classes;

public class AnimalCollection : IAnimalCollection
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

    public void AddAnimals(List<IAnimal> animals)
    {
        AnimalList.AddRange(animals);
    }

    public int GetSmallestSize()
    {
        int result = int.MaxValue;
        foreach(IAnimal animal in AnimalList)
            if (animal.size < result)
                result = animal.size;
        return result;
    }

    public int GetBiggestSize()
    {
        int result = int.MinValue;
        foreach (IAnimal animal in AnimalList)
            if (animal.size > result)
                result = animal.size;
        return result;
    }

    public int GetBiggestHerbivoreSize()
    {
        int result = int.MinValue;
        foreach (Herbivore animal in AnimalList.OfType<Herbivore>())
            if (animal.size > result)
                result = animal.size;
        return result;
    }

    public void sortAnimalListMedium()
    {
        List<IAnimal> tempList = new();
        List<IAnimal> big = new();
        List<IAnimal> medium = new();
        List<IAnimal> small = new();
        foreach (Carnivore carnivore in AnimalList.OfType<Carnivore>())
        {

            if (carnivore.size == 5)
                big.Add(carnivore);
            else if (carnivore.size == 1)
                small.Add(carnivore);
            else
                medium.Add(carnivore);

        }
        tempList.AddRange(medium);
        tempList.AddRange(big);
        tempList.AddRange(small);
        big = new();
        medium = new();
        small = new();
        foreach (Herbivore herbivore in AnimalList.OfType<Herbivore>())
        {

            if (herbivore.size == 5)
                big.Add(herbivore);
            else if (herbivore.size == 1)
                small.Add(herbivore);
            else
                medium.Add(herbivore);

        }
        tempList.AddRange(medium);
        tempList.AddRange(big);
        tempList.AddRange(small);
        AnimalList = tempList;
    }

    public void sortAnimalListBig()
    {
        List<IAnimal> tempList = new();
        List<IAnimal> big = new();
        List<IAnimal> medium = new();
        List<IAnimal> small = new();
        foreach (Carnivore carnivore in AnimalList.OfType<Carnivore>())
        {

            if (carnivore.size == 5)
                big.Add(carnivore);
            else if (carnivore.size == 1)
                small.Add(carnivore);
            else
                medium.Add(carnivore);

        }
        tempList.AddRange(big);
        tempList.AddRange(medium);
        tempList.AddRange(small);
        big = new();
        medium = new();
        small = new();
        foreach (Herbivore herbivore in AnimalList.OfType<Herbivore>())
        {

            if (herbivore.size == 5)
                big.Add(herbivore);
            else if (herbivore.size == 1)
                small.Add(herbivore);
            else
                medium.Add(herbivore);

        }
        tempList.AddRange(big);
        tempList.AddRange(medium);
        tempList.AddRange(small);
        AnimalList = tempList;
    }
}
