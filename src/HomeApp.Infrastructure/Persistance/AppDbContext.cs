using HomeApp.Application.Common.Interfaces;
using HomeApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HomeApp.Infrastructure.Persistance;

public partial class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options), IAppDbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<HomeProjectContact>()
            .HasKey(x => new { x.HomeProjectId, x.ContactId });

        modelBuilder.Entity<HomeProjectMaterial>()
            .HasKey(x => new { x.HomeProjectId, x.MaterialId });

        modelBuilder.Entity<ProjectNotePhoto>()
            .HasKey(x => new { x.NoteId, x.PhotoId });

        modelBuilder.Entity<HomeProjectTool>()
            .HasKey(x => new { x.HomeProjectId, x.ToolId });
    }
}
