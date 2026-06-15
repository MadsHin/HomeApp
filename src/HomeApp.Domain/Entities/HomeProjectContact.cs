namespace HomeApp.Domain.Entities;

public class HomeProjectContact
{
    public Guid HomeProjectId { get; set; }
    public required HomeProject HomeProject { get; set; }

    public Guid ContactId { get; set; }
    public required Contact Contact { get; set; }

    public string? Role { get; set; }
}