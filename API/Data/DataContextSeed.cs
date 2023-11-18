using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public partial class DataContext
    {
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Shopper>().HasData
                (
                    new Shopper { Id = 1, ShopperName = "Till" },
                    new Shopper { Id = 2, ShopperName = "Ida" },
                    new Shopper { Id = 3, ShopperName = "Flo" },
                    new Shopper { Id = 4, ShopperName = "Eli" },
                    new Shopper { Id = 5, ShopperName = "Jon" }                                                                                                               
                );

            modelBuilder.Entity<Item>().HasData
               (
                   new Item { Id = 1, ItemName = "Pepper" },
                   new Item { Id = 2, ItemName = "Soap"},
                   new Item { Id = 3, ItemName = "Salmon" },
                   new Item { Id = 4, ItemName = "Milk" },
                   new Item { Id = 5, ItemName = "Lightbulb" }                                   
               );
        }
    }
}
