using API.Entities;

namespace API.Entities
{
    public class ShoppingList
    {
        public int Id { get; set; }
        public string ListName { get; set; }
        public DateTime DateCreated { get; set; }        
        public ICollection<Item> Items { get; set; }
    }
}
