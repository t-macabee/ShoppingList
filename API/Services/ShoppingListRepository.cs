using API.Data;
using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class ShoppingListRepository : IShoppingListRepository
    {
        private DataContext context { get; set; }

        public ShoppingListRepository(DataContext context)
        {
            this.context = context;
        }

        public void Create(ShoppingList shoppingList)
        {
            context.ShoppingLists.Add(shoppingList);
        }

        public void Remove(ShoppingList shoppingList)
        {
            context.ShoppingLists.Remove(shoppingList);
        }

        public async Task<IEnumerable<ShoppingList>> GetAllLists()
        {
            return await context.ShoppingLists
                .Include(x => x.Shopper)
                .Include(x => x.ShoppingListItems)
                .ThenInclude(x => x.Item)
                .ToListAsync();
        }

        public async Task<ShoppingList> GetListForShopper(int shopperId)
        {
            return await context.ShoppingLists
                .Include(x => x.Shopper)
                .Include(x => x.ShoppingListItems)
                .ThenInclude(x => x.Item)
                .FirstOrDefaultAsync(x => x.ShopperId == shopperId);
        }

        public async Task<ShoppingList> GetListById(int shoppingListId)
        {
            return await context.ShoppingLists
                .Include(x => x.Shopper)
                .Include(x => x.ShoppingListItems)
                .ThenInclude(x => x.Item)
                .FirstOrDefaultAsync(x => x.Id == shoppingListId);
        }

        public async Task<int> GetItemCount(int itemId)
        {
            return await context.ShoppingListItems.CountAsync(x => x.ItemId == itemId);
        }        
    }
}
