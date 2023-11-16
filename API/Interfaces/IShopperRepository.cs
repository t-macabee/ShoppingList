using API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.NewFolder
{
    public interface IShopperRepository
    {
        Task<IEnumerable<Shopper>> GetShoppersAsync();
        Task<Shopper> GetShopperByIdAsync(int shopperId);
    }
}
