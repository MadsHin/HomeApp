namespace HomeApp.Domain.Entities;

public class ProjectExpense
{
    public Guid Id { get; set; }
    public required string Description { get; set; }
    public decimal Amount { get; set; }
    public DateOnly Date { get; set; }
    public DateTime CreatedAt { get; set; }

    public Guid HomeProjectId { get; set; }
    public HomeProject HomeProject { get; set; } = null!;
}
