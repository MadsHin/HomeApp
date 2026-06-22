namespace HomeApp.Domain.Entities;

public class Contact
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public string? Phone { get; set; }
    public string? JobTitle { get; set; }
    public string? Notes { get; set; }
    public ICollection<HomeProjectContact> HomeProjects { get; set; } = [];
}
