namespace HomeApp.Domain.Entities;

public class StorageLocation
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public string? Notes { get; set; }
    public ICollection<Tool> Tools { get; set; } = [];
    public ICollection<Material> Materials { get; set; } = [];
}
