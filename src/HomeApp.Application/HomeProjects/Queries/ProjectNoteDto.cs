namespace HomeApp.Application.HomeProjects.Queries;

public record ProjectNoteDto(
    Guid Id,
    string Content,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    List<PhotoDto> Photos
);
