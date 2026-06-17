namespace HomeApp.Domain.Entities;

public class ProjectNote
{
    public Guid Id { get; set; }
    public required string Content { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public Guid HomeProjectId { get; set; }
    public HomeProject HomeProject { get; set; } = null!;

    public ICollection<ProjectNotePhoto> NotePhotos { get; set; } = [];
}
