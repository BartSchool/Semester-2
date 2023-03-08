using CircusTrein.Core.Interfaces;

namespace CircusTrein.Core.Classes;

public class Train
{
    public List<Cart> cartList { get; private set; }
    public AnimalCollection AnimalCollection { get; private set; }
	public Train()
	{
		cartList = new();
        AnimalCollection = new();
	}

    public void AddCart(Cart cart)
    {
        cartList.Add(cart);
    }

    public void DistributeAnimals()
    {
        if (ShouldSortByBig())
            DistributeUsingBig();
        else
            DistributeUsingMedium();
    }

    private void DistributeUsingBig()
    {
        AnimalCollection.sortAnimalListBig();
        while (AnimalCollection.AnimalList.Count > 0)
        {
            TryAddNewCart(cartList, AnimalCollection);
            Cart lastCart = cartList.Last();
            int i = 0;
            while (i < AnimalCollection.AnimalList.Count)
            {
                IAnimal animal = AnimalCollection.AnimalList[i];
                if (lastCart.TryAddAnimal(animal))
                    AnimalCollection.AnimalList.Remove(animal);
                else
                    i++;
            }
        }
    }

    private void DistributeUsingMedium()
    {
        AnimalCollection.sortAnimalListMedium();
        while (AnimalCollection.AnimalList.Count > 0)
        {
            TryAddNewCart(cartList, AnimalCollection);
            Cart lastCart = cartList.Last();
            int i = 0;
            while (i < AnimalCollection.AnimalList.Count)
            {
                IAnimal animal = AnimalCollection.AnimalList[i];
                if (lastCart.TryAddAnimal(animal))
                    AnimalCollection.AnimalList.Remove(animal);
                else
                    i++;
            }
        }
    }

    private int AmountOfCartsSortingByBig()
    {
        AnimalCollection.sortAnimalListBig();
        AnimalCollection tempCollection = new();
        tempCollection.TryAddAnimal(AnimalCollection.AnimalList);
        List<Cart> carts = new List<Cart>();

        while (tempCollection.AnimalList.Count > 0)
        {
            TryAddNewCart(carts, tempCollection);
            Cart lastCart = carts.Last();
            int i = 0;
            while (i < tempCollection.AnimalList.Count)
            {
                IAnimal animal = tempCollection.AnimalList[i];
                if (lastCart.TryAddAnimal(animal))
                    tempCollection.AnimalList.Remove(animal);
                else
                    i++;
            }
        }

        return carts.Count;
    }

    private int AmountOfCartsSortingByMedium()
    {
        AnimalCollection.sortAnimalListMedium();
        AnimalCollection tempCollection = new();
        tempCollection.TryAddAnimal(AnimalCollection.AnimalList);
        List<Cart> carts = new List<Cart>();

        while (tempCollection.AnimalList.Count > 0)
        {
            TryAddNewCart(carts, tempCollection);
            Cart lastCart = carts.Last();
            int i = 0;
            while (i < tempCollection.AnimalList.Count)
            {
                IAnimal animal = tempCollection.AnimalList[i];
                if (lastCart.TryAddAnimal(animal))
                    tempCollection.AnimalList.Remove(animal);
                else
                    i++;
            }
        }

        return carts.Count;
    }

    private void TryAddNewCart(List<Cart> carts, AnimalCollection animalCollection)
    {
        if (carts.Count == 0)
            carts.Add(new());
        Cart lastCart = carts.Last();
        if (lastCart.GetSpace() < animalCollection.GetSmallestSize())
            carts.Add(new());
        else if (GetCarnivoreSize(lastCart) >= animalCollection.GetBiggestHerbivoreSize())
            carts.Add(new());
        else if (lastCart.GetSpace() < animalCollection.GetBiggestSize())
            carts.Add(new());
    }

    public int GetCarnivoreSize(IAnimalCollection collection)
    {
        int result = 0;
        foreach (ICarnivore carnivore in collection.AnimalList.OfType<ICarnivore>())
            if (carnivore.size > result)
                result = carnivore.size;
        return result;
    }

    private bool ShouldSortByBig()
    {
        if (AmountOfCartsSortingByBig() > AmountOfCartsSortingByMedium())
            return false;
        return true;
    }

}
