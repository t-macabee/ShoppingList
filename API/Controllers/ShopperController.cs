using API.DTOs;
using API.Entities;
using API.Interfaces;
using API.NewFolder;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{    
    public class ShopperController : BaseAPIController
    {
        private IUnitOfWork uow { get; set; }
        private IMapper mapper { get; set; }

        public ShopperController(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShopperDto>>> GetShoppers()
        {
            var shoppers = await uow.ShopperRepository.GetShoppers();
            return Ok(mapper.Map<IEnumerable<ShopperDto>>(shoppers));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Shopper>> GetShopperById(int id)
        {
            var shopper = await uow.ShopperRepository.GetShopperById(id);
            return Ok(mapper.Map<ShopperDto>(shopper));
        }
    }
}
