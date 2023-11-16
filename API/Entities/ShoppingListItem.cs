namespace API.Entities
{
    public class ShoppingListItem
    {
        
        public int ShoppingListId { get; set; }
        public ShoppingList ShoppingList { get; set; }

        public int ItemId { get; set; }
        public Item Item { get; set; }
    }
}
