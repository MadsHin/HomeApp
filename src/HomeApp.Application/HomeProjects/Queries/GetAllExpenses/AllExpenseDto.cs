namespace HomeApp.Application.HomeProjects.Queries;

public record AllExpenseDto(
    Guid Id,
    Guid ProjectId,
    string ProjectTitle,
    string Description,
    decimal Amount,
    DateOnly Date
);
