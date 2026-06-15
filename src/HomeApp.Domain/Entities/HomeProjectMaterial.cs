namespace HomeApp.Domain.Entities;

public class HomeProjectMaterial
{
    public Guid HomeProjectId { get; set; }
    public required HomeProject HomeProject { get; set; }

    public Guid MaterialId { get; set; }
    public required Material Material { get; set; }

    public string? Quantity { get; set; }
}