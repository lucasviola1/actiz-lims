using ActizLims.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ActizLims.API.Data
{
    public class configDbContext : DbContext
    {
        public configDbContext(DbContextOptions<configDbContext> options) : base(options)
        {
        }

        public DbSet<Amostra> Amostras => Set<Amostra>();
        public DbSet<User> Users => Set<User>();
    }
}
