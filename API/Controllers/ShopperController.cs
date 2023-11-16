using API.Data;
using API.Entities;
using API.NewFolder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{    
    public class ShopperController : BaseAPIController
    {
        private IShopperRepository shopperRepository { get; set; }

        public ShopperController(IShopperRepository shopperRepository)
        {
            this.shopperRepository = shopperRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Shopper>>> GetShoppers() 
        {
            var shoppers = await shopperRepository.GetShoppersAsync();
            return Ok(shoppers);
        }

        [HttpGet("id")]
        public async Task<ActionResult<Shopper>> GetShopperById(int shopperId)
        {
            var shopper = await shopperRepository.GetShopperByIdAsync(shopperId);
            return Ok(shopper);
        }
    }
}
