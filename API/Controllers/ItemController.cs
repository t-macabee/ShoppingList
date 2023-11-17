using API.DTOs;
using API.Entities;
using API.Interfaces;
using API.NewFolder;
using API.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ItemController : BaseAPIController
    {
        private IUnitOfWork uow { get; set; }
        private IMapper mapper { get; set; }

        public ItemController(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemDto>>> GetItems()
        {
            var items = await uow.ItemRepository.GetItems();
            return Ok(mapper.Map<IEnumerable<ItemDto>>(items));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDto>> GetItemById(int id)
        {
            var item = await uow.ItemRepository.GetItemById(id);
            return Ok(mapper.Map<ItemDto>(item));
        }        
    }
}
