namespace HomeApp.Domain.Entities;

public class Tool
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public string? Category { get; set; }
    public string? Icon { get; set; }
    public string? Notes { get; set; }
    public int SortOrder { get; set; }
    public ToolStatus Status { get; set; } = ToolStatus.Owned;
    public string? StatusNote { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid? StorageLocationId { get; set; }
    public StorageLocation? StorageLocation { get; set; }
    public ICollection<HomeProjectTool> HomeProjects { get; set; } = [];
}
