using BookManagement.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.DAL;

public sealed class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Genre> Genres { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder
            .AddInterceptors(new SoftDeleteInterceptor());

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("uuid-ossp");

        modelBuilder.Entity<Book>()
            .HasQueryFilter(x => x.IsDeleted == false)
            .Property(e => e.Id)
            .ValueGeneratedOnAdd()
            .HasDefaultValueSql("uuid_generate_v4()");  
        
        modelBuilder.Entity<Author>()
            .HasQueryFilter(x => x.IsDeleted == false)
            .Property(e => e.Id)
            .ValueGeneratedOnAdd()
            .HasDefaultValueSql("uuid_generate_v4()");  
        
        modelBuilder.Entity<Genre>()
            .HasQueryFilter(x => x.IsDeleted == false)
            .Property(e => e.Id)
            .ValueGeneratedOnAdd()
            .HasDefaultValueSql("uuid_generate_v4()");

    }
}