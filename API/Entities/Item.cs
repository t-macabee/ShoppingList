namespace API.Entities
{
    public class Item
    {
        public int Id { get; set; }
        public string ItemName { get; set; }

        public ICollection<ShoppingListItem> ShoppingListItems { get; set; }
    }
}
