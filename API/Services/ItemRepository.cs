using API.Data;
using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class ItemRepository : IItemRepository
    {
        private DataContext context { get; set; }

        public ItemRepository(DataContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Item>> GetItems()
        {
            return await context.Items.ToListAsync();
        }

        public async Task<Item> GetItemById(int itemId)
        {
            return await context.Items.FirstOrDefaultAsync(x => x.Id == itemId);
        }        
    }
}
