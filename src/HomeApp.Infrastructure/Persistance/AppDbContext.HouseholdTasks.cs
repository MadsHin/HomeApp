using HomeApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HomeApp.Infrastructure.Persistance;

public partial class AppDbContext
{
    public DbSet<HouseholdTask> HouseholdTasks { get; set; }
}
