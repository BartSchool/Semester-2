namespace CircusTrein.Core.Interfaces;

public interface IHerbivore : IAnimal
{
    bool CanJoinCollection(List<IAnimal> animalList);
}
