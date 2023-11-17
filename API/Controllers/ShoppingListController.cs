﻿using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class ShoppingListController : BaseAPIController
    {
        private IUnitOfWork uow { get; set; }
        private IMapper mapper { get; set; }

        public ShoppingListController(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;            
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<ShoppingListDto>>> GetAllLists()
        {
            var lists = await uow.ShoppingListRepository.GetAllLists();
            return Ok(mapper.Map<IEnumerable<ShoppingListDto>>(lists));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ShoppingListDto>> GetListById(int id)
        {
            var list = await uow.ShoppingListRepository.GetListById(id);
            return Ok(mapper.Map<ShoppingListDto>(list));
        }

        [HttpGet("listByShopper/{id}")]
        public async Task<ActionResult<ShoppingListDto>> GetListForShopper(int id)
        {
            var lists = await uow.ShoppingListRepository.GetListForShopper(id);
            return Ok(mapper.Map<ShoppingListDto>(lists));
        }

        [HttpPost("create-list/{shopperId}/{listName}")]
        public async Task<IActionResult> CreateShoppingList(int shopperId, string listName)
        {
            var shopper = await uow.ShopperRepository.GetShopperById(shopperId);

            if (shopper == null)
                return BadRequest("Shopper doesn't exist");

            if (shopper.ShoppingList != null)
                return BadRequest("Shopper already has a shopping list");

            var newList = new ShoppingList
            {
                ListName = listName,
                ShopperId = shopperId
            };

            uow.ShoppingListRepository.Create(newList);

            if (await uow.Complete())
                return Ok(mapper.Map<ShoppingListDto>(newList));

            return BadRequest("Failed to create a new list");
        }


        [HttpDelete("remove-list/{shopperId}/{listId}")]
        public async Task<IActionResult> RemoveShoppingList(int shopperId, int listId)
        {
            var shopper = await uow.ShopperRepository.GetShopperById(shopperId);

            if (shopper == null)
                return BadRequest("Shopper doesn't exist");

            if (shopper.ShoppingList == null || shopper.ShoppingList.Id != listId)
                return BadRequest("Shopper does not have the specified shopping list");

            uow.ShoppingListRepository.Remove(shopper.ShoppingList);

            if (await uow.Complete())
                return Ok();

            return BadRequest("Failed to remove the shopping list");
        }

        [HttpPost("add-item/{listId}/{itemId}")]
        public async Task<IActionResult> AddItemToList(int listId, int itemId)
        {
            var shoppingList = await uow.ShoppingListRepository.GetListById(listId);

            if (shoppingList == null)
                return BadRequest("Shopping list not found");

            var item = await uow.ItemRepository.GetItemById(itemId);

            if (item == null)
                return BadRequest("Item not found");

            if (shoppingList.ShoppingListItems.Any(x => x.ItemId == itemId))
                return BadRequest("Item is already in the shopping list");

            var itemCountInOtherLists = await uow.ShoppingListRepository.GetItemCount(itemId);

            if (itemCountInOtherLists >= 3)
                return BadRequest("Item cannot be added to more than three shopping lists");

            shoppingList.ShoppingListItems.Add(new ShoppingListItem { ItemId = itemId });

            if (await uow.Complete())
                return Ok(mapper.Map<ShoppingListDto>(shoppingList));

            return BadRequest("Failed to add item to the shopping list");
        }


        [HttpDelete("remove-item/{listId}/{itemId}")]
        public async Task<IActionResult> RemoveItemFromList(int listId, int itemId)
        {
            var shoppingList = await uow.ShoppingListRepository.GetListById(listId);

            if (shoppingList == null)
                return BadRequest("Shopping list not found");

            var item = await uow.ItemRepository.GetItemById(itemId);

            if (item == null)
                return BadRequest("Item not found");
            
            var shoppingListItem = shoppingList.ShoppingListItems.FirstOrDefault(x => x.ItemId == itemId);

            if (shoppingListItem == null)
                return BadRequest("Item is not in the shopping list");

            shoppingList.ShoppingListItems.Remove(shoppingListItem);

            if (await uow.Complete())
                return Ok(mapper.Map<ShoppingListDto>(shoppingList));

            return BadRequest("Failed to remove item from the shopping list");
        }
    }
}
