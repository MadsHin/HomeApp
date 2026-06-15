namespace HomeApp.Domain.Entities;

public class ProgressEntry
{
    public Guid Id { get; set; }
    public DateOnly Date { get; set; }
    public required string Note { get; set; }

    public Guid HomeProjectId { get; set; }
    public HomeProject HomeProject { get; set; } = null!;
}
