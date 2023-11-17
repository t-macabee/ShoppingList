using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public partial class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }
         
        public DbSet<Shopper> Shoppers { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ShoppingList> ShoppingLists { get; set; }
        public DbSet<ShoppingListItem> ShoppingListItems { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<ShoppingListItem>()
                .HasKey(sl => new { sl.ShoppingListId, sl.ItemId });

            modelBuilder.Entity<ShoppingListItem>()
                .HasOne(sl => sl.ShoppingList)
                .WithMany(sl => sl.ShoppingListItems)
                .HasForeignKey(sl => sl.ShoppingListId)
                .OnDelete(DeleteBehavior.Cascade); 

            modelBuilder.Entity<ShoppingListItem>()
                .HasOne(sl => sl.Item)
                .WithMany(i => i.ShoppingListItems)
                .HasForeignKey(sl => sl.ItemId)
                .OnDelete(DeleteBehavior.Cascade);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
