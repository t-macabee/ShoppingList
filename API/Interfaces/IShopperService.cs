using API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.NewFolder
{
    public interface IShopperService
    {
        Task<IEnumerable<Shopper>> GetShoppersAsync();
    }
}
