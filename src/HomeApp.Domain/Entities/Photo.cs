namespace HomeApp.Domain.Entities;

public class Photo
{
    public Guid Id { get; set; }

    public Guid HomeProjectId { get; set; }
    public required HomeProject HomeProject { get; set; }
}
