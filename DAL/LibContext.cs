using System;
using DAL;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DAL
{
    public class LibContext : DbContext
    {
        public LibContext(DbContextOptions<LibContext> options)
            : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<LibContext>
{
    public LibContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<LibContext>();

        // Замените строку подключения на свою!
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=lib.books;Username=postgres;Password=root");

        return new LibContext(optionsBuilder.Options);
    }
}