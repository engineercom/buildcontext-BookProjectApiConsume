using Microsoft.EntityFrameworkCore;

namespace BookProject.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
               new Book { Id = 1, Title = "Gurur ve ÖnYargı", Author = "Jane Austen", Price = 180 },
               new Book { Id = 2, Title = "Martin Eden", Author = "Jack London", Price = 125 },
                new Book { Id = 3, Title = "Beyaz Diş", Author = "Jack London", Price = 45 },
                new Book { Id = 4, Title = "Kaptan Singleton", Author = "Daniel Defoe", Price = 330 },
                new Book { Id = 5, Title = "Akrep Kral", Author = "William Golding", Price = 384 },
                new Book { Id = 6, Title = "İstanbul Treni", Author = "Graham Greene", Price = 560 },
                new Book { Id = 7, Title = "Macbeth", Author = "William Shakespeare", Price = 300 }

                );
        }
    }
}
