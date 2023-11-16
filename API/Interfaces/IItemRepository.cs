using API.Entities;

namespace API.Interfaces
{
    public interface IItemRepository
    {
        Task<IEnumerable<Item>> GetItems();
        Task<Item> GetItemById(int itemId);
    }
}
