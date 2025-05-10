using System;

public class LibContext : DbContext
{
    DbSet<User> Users { get; set; }

    public LibContext(DbContextOptions<LibContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
