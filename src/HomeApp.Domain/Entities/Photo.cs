namespace HomeApp.Domain.Entities;

public class Photo
{
    public Guid Id { get; set; }
    public required string FileName { get; set; }
    public required string StoredFileName { get; set; }
    public string? Caption { get; set; }
    public DateTime UploadedAt { get; set; }

    public Guid HomeProjectId { get; set; }
    public HomeProject HomeProject { get; set; } = null!;
}
