﻿namespace API.Entities
{
    public class Item
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public string Type { get; set; }

        public ICollection<ShoppingListItem> ShoppingListItems { get; set; }
    }
}
