using A1.data.Entities;
using Microsoft.EntityFrameworkCore;

namespace A1.data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
    {

        
        
    }

    public DbSet<Company> Companies { get; set; }

    public DbSet<Station> Stations { get; set; }
}
// dotnet ef migrations add AddCompany
// dotnet ef database update
