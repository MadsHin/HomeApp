namespace HomeApp.Domain.Entities;

public class ProjectTimelineEvent
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public DateOnly? Date { get; set; }
    public int SortOrder { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime CreatedAt { get; set; }

    public Guid HomeProjectId { get; set; }
    public HomeProject HomeProject { get; set; } = null!;
}
