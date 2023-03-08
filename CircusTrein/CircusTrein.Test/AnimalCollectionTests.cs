using CircusTrein.Core.Classes;

namespace CircusTrein.Test;

public class AnimalCollectionTests
{
    AnimalGenerator AG = new();

    [Fact]
    public void CanSortAnimalList()
    {
        AnimalCollection collection = new AnimalCollection();
        collection.TryAddAnimal(AG.getAnimals(1, 1, 1, 1, 1, 1));

        collection.sortAnimalListMedium();

        Assert.Equal(3, collection.AnimalList[0].size);
        Assert.Equal(5, collection.AnimalList[1].size);
        Assert.Equal(1, collection.AnimalList[2].size);
        Assert.Equal(3, collection.AnimalList[3].size);
        Assert.Equal(5, collection.AnimalList[4].size);
        Assert.Equal(1, collection.AnimalList[5].size);

        collection.sortAnimalListBig();

        Assert.Equal(5, collection.AnimalList[0].size);
        Assert.Equal(3, collection.AnimalList[1].size);
        Assert.Equal(1, collection.AnimalList[2].size);
        Assert.Equal(5, collection.AnimalList[3].size);
        Assert.Equal(3, collection.AnimalList[4].size);
        Assert.Equal(1, collection.AnimalList[5].size);
    }
}
