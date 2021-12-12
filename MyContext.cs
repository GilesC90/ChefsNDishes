using Microsoft.EntityFrameworkCore;


namespace CRUDelicious.Models.Home
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options) {}
        public DbSet<Dish> Dishes {get; set; }
        public DbSet<Chef> Chefs {get; set; }
    }
}