using API.Entities;

namespace API.NewFolder
{
    public interface IShopperRepository
    {
        Task<IEnumerable<Shopper>> GetShoppers();
        Task<Shopper> GetShopperById(int shopperId);
    }
}
