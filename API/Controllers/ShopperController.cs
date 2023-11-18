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
    }
}
