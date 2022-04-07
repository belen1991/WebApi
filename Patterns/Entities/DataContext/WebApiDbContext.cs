using Entities.Domain;
using Microsoft.EntityFrameworkCore;

namespace Entities.DataContext
{
    public class WebApiDbContext : DbContext
    {
        public WebApiDbContext() { }

        public WebApiDbContext(DbContextOptions<WebApiDbContext> options)
            :base(options)
        {
        }

        public DbSet<Album> Albumes { get; set; }
        public DbSet<Artista> Artistas { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Movement> Movements { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseInMemoryDatabase("Patterns_DB");
        }
    }
}
