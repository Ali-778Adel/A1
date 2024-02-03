using System.Reflection;
using System.Security.Claims;
using A1.data.Entities;
using Microsoft.EntityFrameworkCore;

namespace A1.data;

public class AppDbContext(DbContextOptions<AppDbContext> dbContextOptions, IHttpContextAccessor httpContextAccessor)
    : DbContext(dbContextOptions)
{
    private readonly Guid? _userId = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier) != null
        ? Guid.Parse(httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier)!)
        : null;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetCallingAssembly());
    }
    

    public DbSet<Company> Companies { get; set; }
    public DbSet<Station> Stations { get; set; }
    public DbSet<Unit> Units { get; set; }
}