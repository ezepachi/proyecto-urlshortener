using Microsoft.EntityFrameworkCore;
using proyecto_urlshortener.Entities;

namespace URLShortener.Data
{
    public class UrlShortenerContext : DbContext
    {
        public DbSet<Url> Urls { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public UrlShortenerContext(DbContextOptions<UrlShortenerContext> options) : base(options) { } //Acá estamos llamando al constructor de DbContext que es el que acepta las opciones

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //RELACIONES DE TABLAS
            //has many es el lado de 1 de la relación 1 a muchos (1 usuario tiene muchos urls)
            //with one es el lado de muchos de la relación 1 a muchos (1 usuario tiene muchos urls)
            //has foreign key es el lado de muchos de la relación 1 a muchos (1 usuario tiene muchos urls)
            
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Urls)
                .WithOne(u => u.Category)
                .HasForeignKey(u => u.CategoryId);

            modelBuilder.Entity<Category>().HasData(
                new Category() { Id = 1, Name = "Redes sociales" },
                new Category() { Id = 2, Name = "Plataforma streaming" },
                new Category() { Id = 3, Name = "Peliculas" }
            );

            modelBuilder.Entity<User>()
                .HasMany(u => u.Urls)
                .WithOne(ur => ur.User)
                .HasForeignKey(ur => ur.UserId);
            base.OnModelCreating(modelBuilder);
        }
    }

}