using API.Entities;

namespace API.DTOs
{
    public class ShopperDto
    {
        public int Id { get; set; }
        public string ShopperName { get; set; }
        public ShoppingListDto ShoppingList { get; set; }
    }
}
