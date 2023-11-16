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

        public async Task<IEnumerable<Shopper>> GetShoppersAsync()
        {
            return await context.Shoppers
                .Include(x => x.ShoppingList)
                .ThenInclude(x => x.Items)
                .ToListAsync();
        }

        public async Task<Shopper> GetShopperByIdAsync(int shopperId)
        {
            return await context.Shoppers
                .Include(x => x.ShoppingList)
                .ThenInclude(x => x.Items)
                .FirstOrDefaultAsync(x => x.Id == shopperId);
        }
    }
}
