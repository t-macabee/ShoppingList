using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{    
    public class ShopperController : BaseAPIController
    {
        private DataContext context { get; set; }

        public ShopperController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Shopper>>> GetShoppers() 
        {
            return await context.Shoppers.ToListAsync();
        }
    }
}
