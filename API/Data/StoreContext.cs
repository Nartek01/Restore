using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class StoreContext : DbContext /* Använder Entity Framework */
    {
        public StoreContext(DbContextOptions options) : base(options) // Skicka med options här annars lämna tomt
        {
        }

        public DbSet<Product> Products { get; set; }

    }
}