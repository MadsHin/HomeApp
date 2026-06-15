using HomeApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HomeApp.Infrastructure.Persistance;

public partial class AppDbContext
{
    public DbSet<FamilyMember> FamilyMembers { get; set; }
}
