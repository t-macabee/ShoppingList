using API.Entities;

namespace API.Interfaces
{
    public interface IShoppingListRepository
    {
        void Create(ShoppingList shoppingList);
        void Remove(ShoppingList shoppingList);

        Task<ShoppingList> GetListById(int shoppingListId);
        Task<ShoppingList> GetListForShopper(int shopperId);

        Task<int> GetItemCount(int itemId);
    }
}
