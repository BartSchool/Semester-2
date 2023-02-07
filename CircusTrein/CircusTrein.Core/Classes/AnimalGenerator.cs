using CircusTrein.Core.Interfaces;

namespace CircusTrein.Core.Classes;

public class AnimalGenerator
{
    public Carnivore GetCarnivore(int size)
    {
        return new Carnivore(size);
    }
    public Herbivore GetHerbivore(int size)
    {
        return new Herbivore(size);
    }
    public List<Herbivore> getHerbivores(int small, int medium, int big)
    {
        List<Herbivore> list = new();
        for (int i = 0; i < small; i++)
            list.Add(GetHerbivore(1));
        for (int i = 0; i < medium; i++)
            list.Add(GetHerbivore(3));
        for (int i = 0; i < big; i++)
            list.Add(GetHerbivore(5));
        return list;
    }
    public List<Carnivore> getCarnivores(int small, int medium, int big)
    {
        List<Carnivore> list = new();
        for (int i = 0; i < small; i++)
            list.Add(GetCarnivore(1));
        for (int i = 0; i < medium; i++)
            list.Add(GetCarnivore(3));
        for (int i = 0; i < big; i++)
            list.Add(GetCarnivore(5));
        return list;
    }
    public List<IAnimal> getAnimals(int smallHerbivores, int mediumHerbivores, int bigHerbivores, int smallCarnivores, int mediumCarnivores, int bigCarnivores)
    {
        List<IAnimal> list = new();
        list.AddRange(getHerbivores(smallHerbivores, mediumHerbivores, bigHerbivores));
        list.AddRange(getCarnivores(smallCarnivores, mediumCarnivores, bigCarnivores));
        return list;
    }
}