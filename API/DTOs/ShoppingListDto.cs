﻿namespace API.DTOs
{
    public class ShoppingListDto
    {
        public int Id { get; set; }
        public string ListName { get; set; }
        public IEnumerable<ItemDto> Items { get; set; }
    }
}
