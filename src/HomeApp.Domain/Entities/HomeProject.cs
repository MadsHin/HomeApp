using HomeApp.Domain.Enums;

namespace HomeApp.Domain.Entities;

public class HomeProject
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }
    public ProjectStatus Status { get; set; }
    public decimal? Budget { get; set; }
    public DateOnly? StartDate { get; set; }
    public DateOnly? CompletedDate { get; set; }

    public ICollection<HomeProjectMaterial> Materials { get; set; } = [];
    public ICollection<HomeProjectContact> Contacts { get; set; } = [];
    public ICollection<ProgressEntry> ProgressEntries { get; set; } = [];
    public ICollection<ProjectLink> Links { get; set; } = [];
    public ICollection<Photo> Photos { get; set; } = [];
}
