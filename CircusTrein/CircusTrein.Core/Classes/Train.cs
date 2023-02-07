namespace CircusTrein.Core.Classes;

public class Train
{
    public List<Cart> cartList { get; private set; }
	public Train()
	{
		cartList = new();
	}

    public void AddCart(Cart cart)
    {
        cartList.Add(cart);
    }
}
