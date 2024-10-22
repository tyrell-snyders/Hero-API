using Hero_API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hero_API.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Hero> Heroes { get; set; }
    }
}
