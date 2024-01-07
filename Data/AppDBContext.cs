using A1.data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace A1.data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var stringConverter = new ValueConverter<List<string>, string>(
            v => string.Join(',', v),
            v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList()
        );

        modelBuilder.Entity<Station>().Property(x => x.MoreServices).HasConversion(stringConverter);
        modelBuilder.Entity<Station>().Property(x => x.ConditionsAr).HasConversion(stringConverter);
        modelBuilder.Entity<Station>().Property(x => x.ConditionsEn).HasConversion(stringConverter);
        modelBuilder.Entity<Station>().Property(x => x.Image).HasConversion(
            v => Convert.ToBase64String(v),
            v => Convert.FromBase64String(v)
        );
        modelBuilder.Entity<Station>().Property(x => x.Layout).HasConversion(
            v => Convert.ToBase64String(v),
            v => Convert.FromBase64String(v)
        );
    }

    public DbSet<Company> Companies { get; set; }

    public DbSet<Station> Stations { get; set; }
}