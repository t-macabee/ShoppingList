namespace API.Entities
{
    public class Shopper
    {
        public int Id { get; set; }
        public string ShopperName { get; set; }
        public ShoppingList ShoppingList { get; set; }
    }
}
