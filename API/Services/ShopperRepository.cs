using API.Data;
using API.Entities;
using API.NewFolder;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class ShopperRepository : IShopperRepository
    {        
        private DataContext context { get; set; }

        public ShopperRepository(DataContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Shopper>> GetShoppers()
        {
            return await context.Shoppers
                .Include(x => x.ShoppingList)
                .ThenInclude(x => x.ShoppingListItems)
                .ThenInclude(x => x.Item)
                .ToListAsync();
        }

        public async Task<Shopper> GetShopperById(int shopperId)
        {
            return await context.Shoppers
                .Include(x => x.ShoppingList)
                .ThenInclude(x => x.ShoppingListItems)
                .ThenInclude(x => x.Item)
                .FirstOrDefaultAsync(x => x.Id == shopperId);
        }
    }
}
