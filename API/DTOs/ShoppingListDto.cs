namespace API.DTOs
{
    public class ShoppingListDto
    {
        public int Id { get; set; }
        public string ListName { get; set; }
        public string ShopperName { get; set; }
        public IEnumerable<string> Items { get; set; }
    }
}
