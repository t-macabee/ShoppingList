using API.Interfaces;
using API.NewFolder;
using API.Services;

namespace API.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private DataContext context;

        public UnitOfWork(DataContext context)
        {
            this.context = context;
        }

        public IItemRepository ItemRepository => new ItemRepository(context);

        public IShopperRepository ShopperRepository => new ShopperRepository(context);

        public IShoppingListRepository ShoppingListRepository => new ShoppingListRepository(context);

        public async Task<bool> Complete()
        {
            return await context.SaveChangesAsync() > 0;
        }        
    }
}
