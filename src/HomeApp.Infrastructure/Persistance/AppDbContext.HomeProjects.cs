using HomeApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HomeApp.Infrastructure.Persistance;

public partial class AppDbContext
{
    public DbSet<HomeProject> HomeProjects { get; set; }
    public DbSet<Material> Materials { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<HomeProjectContact> HomeProjectContacts { get; set; }
    public DbSet<HomeProjectMaterial> HomeProjectMaterials { get; set; }
    public DbSet<ProgressEntry> ProgressEntries { get; set; }
    public DbSet<ProjectLink> ProjectLinks { get; set; }
    public DbSet<Photo> Photos { get; set; }
    public DbSet<ProjectTimelineEvent> ProjectTimelineEvents { get; set; }
    public DbSet<ProjectExpense> ProjectExpenses { get; set; }
    public DbSet<ProjectNote> ProjectNotes { get; set; }
    public DbSet<ProjectNotePhoto> ProjectNotePhotos { get; set; }
}
