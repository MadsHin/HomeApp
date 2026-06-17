namespace HomeApp.Application.HomeProjects.Queries;

public record ProjectTimelineEventDto(
    Guid Id,
    string Title,
    DateOnly? Date,
    int SortOrder,
    bool IsCompleted
);
