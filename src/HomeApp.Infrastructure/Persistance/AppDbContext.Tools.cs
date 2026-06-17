using HomeApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HomeApp.Infrastructure.Persistance;

public partial class AppDbContext
{
    public DbSet<Tool> Tools { get; set; }
    public DbSet<HomeProjectTool> HomeProjectTools { get; set; }
}
