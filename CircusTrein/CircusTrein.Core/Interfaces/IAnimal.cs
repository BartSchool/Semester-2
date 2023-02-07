using CircusTrein.Core.Classes;

namespace CircusTrein.Core.Interfaces;

public interface IAnimal
{
    int size { get; }

    bool CanJoinCart(Cart cart);
}
