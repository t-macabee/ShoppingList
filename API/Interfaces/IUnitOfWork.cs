using API.NewFolder;

namespace API.Interfaces
{
    public interface IUnitOfWork
    {
        IItemRepository ItemRepository { get; }
        IShopperRepository ShopperRepository { get; }
        IShoppingListRepository ShoppingListRepository { get; }

        Task<bool> Complete();
    }
}
