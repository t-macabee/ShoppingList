using API.Entities;

namespace API.Interfaces
{
    public interface IShoppingListRepository
    {
        void Create(ShoppingList shoppingList);
        void Remove(ShoppingList shoppingList);

        Task<IEnumerable<ShoppingList>> GetAllLists();
        Task<ShoppingList> GetListById(int shoppingListId);
        Task<IEnumerable<ShoppingList>> GetListsForShopper(int shopperId);

        Task<int> GetItemCount(int itemId);
        Task<bool> ListExists(string listName, int shopperId);
    }
}
