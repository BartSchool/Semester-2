namespace CircusTrein.Core.Interfaces;

public interface ICarnivore : IAnimal
{
    bool CanEat(IAnimal animal);
    bool CanJoinCollection(List<IAnimal> animalList);
}
