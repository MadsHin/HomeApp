using HomeApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HomeApp.Application.Common.Interfaces;

public interface IAppDbContext
{
    DbSet<Contact> Contacts { get; }
    DbSet<FamilyMember> FamilyMembers { get; }
    DbSet<HomeProject> HomeProjects { get; }
    DbSet<HomeProjectContact> HomeProjectContacts { get; }
    DbSet<HomeProjectMaterial> HomeProjectMaterials { get; }
    DbSet<MaintenanceTask> MaintenanceTasks { get; }
    DbSet<Material> Materials { get; }
    DbSet<Photo> Photos { get; }
    DbSet<ProgressEntry> ProgressEntries { get; }
    DbSet<ProjectLink> ProjectLinks { get; }
    DbSet<ProjectTimelineEvent> ProjectTimelineEvents { get; }
    DbSet<ProjectExpense> ProjectExpenses { get; }
    DbSet<ProjectNote> ProjectNotes { get; }
    DbSet<ProjectNotePhoto> ProjectNotePhotos { get; }
    DbSet<StorageLocation> StorageLocations { get; }
    DbSet<Tool> Tools { get; }
    DbSet<HomeProjectTool> HomeProjectTools { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
