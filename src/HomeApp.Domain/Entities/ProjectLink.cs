namespace HomeApp.Domain.Entities;

public class ProjectLink
{
    public Guid Id { get; set; }
    public required string Label { get; set; }
    public required string Url { get; set; }

    public Guid HomeProjectId { get; set; }
    public HomeProject HomeProject { get; set; } = null!;
}
