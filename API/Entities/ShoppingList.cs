using API.Entities;

namespace API.Entities
{
    public class ShoppingList
    {
        public int Id { get; set; }
        public string ListName { get; set; }

        public int ShopperId { get; set; }
        public Shopper Shopper { get; set; }

        public ICollection<ShoppingListItem> ShoppingListItems { get; set; }
    }
}
