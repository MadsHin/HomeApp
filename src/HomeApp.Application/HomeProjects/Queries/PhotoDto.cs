namespace HomeApp.Application.HomeProjects.Queries;

public record PhotoDto(
    Guid Id,
    string StoredFileName,
    string? Caption,
    string ProjectTitle,
    Guid HomeProjectId,
    DateTime UploadedAt
);
