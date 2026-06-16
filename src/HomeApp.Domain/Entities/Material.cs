namespace HomeApp.Domain.Entities;

public class Material
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public decimal? Quantity { get; set; }
    public string? Unit { get; set; }
    public string? Location { get; set; }
    public string? Notes { get; set; }
    public string? Icon { get; set; }
    public ICollection<HomeProjectMaterial> HomeProjects { get; set; } = [];
}
