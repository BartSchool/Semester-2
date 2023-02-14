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
        if (ShouldIUseBig())
            DistributeUsingBig();
        else
            DistributeUsingMedium();
    }

    private void DistributeUsingBig()
    {
        AnimalCollection.sortAnimalListBig();
        while (AnimalCollection.AnimalList.Count > 0)
        {
            CheckLastCart(cartList, AnimalCollection);
            Cart lastCart = cartList.Last();
            int i = 0;
            while (i < AnimalCollection.AnimalList.Count)
            {
                IAnimal animal = AnimalCollection.AnimalList[i];
                if (animal.CanJoinCart(lastCart))
                {
                    lastCart.AddAnimal(animal);
                    AnimalCollection.AnimalList.Remove(animal);
                }
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
            CheckLastCart(cartList, AnimalCollection);
            Cart lastCart = cartList.Last();
            int i = 0;
            while (i < AnimalCollection.AnimalList.Count)
            {
                IAnimal animal = AnimalCollection.AnimalList[i];
                if (animal.CanJoinCart(lastCart))
                {
                    lastCart.AddAnimal(animal);
                    AnimalCollection.AnimalList.Remove(animal);
                }
                else
                    i++;
            }
        }
    }

    private int CartsUsingBig()
    {
        AnimalCollection.sortAnimalListBig();
        AnimalCollection tempCollection = new();
        tempCollection.AddAnimals(AnimalCollection.AnimalList);
        List<Cart> carts = new List<Cart>();

        while (tempCollection.AnimalList.Count > 0)
        {
            CheckLastCart(carts, tempCollection);
            Cart lastCart = carts.Last();
            int i = 0;
            while (i < tempCollection.AnimalList.Count)
            {
                IAnimal animal = tempCollection.AnimalList[i];
                if (animal.CanJoinCart(lastCart))
                {
                    lastCart.AddAnimal(animal);
                    tempCollection.AnimalList.Remove(animal);
                }
                else
                    i++;
            }
        }

        return carts.Count;
    }

    private int CartsUsingMedium()
    {
        AnimalCollection.sortAnimalListMedium();
        AnimalCollection tempCollection = new();
        tempCollection.AddAnimals(AnimalCollection.AnimalList);
        List<Cart> carts = new List<Cart>();

        while (tempCollection.AnimalList.Count > 0)
        {
            CheckLastCart(carts, tempCollection);
            Cart lastCart = carts.Last();
            int i = 0;
            while (i < tempCollection.AnimalList.Count)
            {
                IAnimal animal = tempCollection.AnimalList[i];
                if (animal.CanJoinCart(lastCart))
                {
                    lastCart.AddAnimal(animal);
                    tempCollection.AnimalList.Remove(animal);
                }
                else
                    i++;
            }
        }

        return carts.Count;
    }

    private void CheckLastCart(List<Cart> carts, AnimalCollection animalCollection)
    {
        if (carts.Count == 0)
            carts.Add(new());
        Cart lastCart = carts.Last();
        if (lastCart.GetSpace() < animalCollection.GetSmallestSize())
            carts.Add(new());
        else if (lastCart.GetCarnivoreSize() >= animalCollection.GetBiggestHerbivoreSize())
            carts.Add(new());
        else if (lastCart.GetSpace() < animalCollection.GetBiggestSize())
            carts.Add(new());
    }

    private bool ShouldIUseBig()
    {
        int big = CartsUsingBig();
        int medium = CartsUsingMedium();

        if (big > medium)
            return false;
        return true;
    }

}
