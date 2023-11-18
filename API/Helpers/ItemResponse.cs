using API.DTOs;

namespace API.Helpers
{
    public class ItemResponse
    {
        public bool CanAddItem { get; set; }
        public ShoppingListDto ShoppingList { get; set; }
    }
}
