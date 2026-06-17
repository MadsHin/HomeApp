namespace HomeApp.Domain.Entities;

public class ProjectNotePhoto
{
    public Guid NoteId { get; set; }
    public ProjectNote Note { get; set; } = null!;

    public Guid PhotoId { get; set; }
    public Photo Photo { get; set; } = null!;
}
