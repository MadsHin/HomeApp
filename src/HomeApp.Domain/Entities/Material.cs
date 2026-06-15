namespace HomeApp.Domain.Entities;

public class Material
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public ICollection<HomeProjectMaterial> HomeProjects { get; set; } = [];
}
