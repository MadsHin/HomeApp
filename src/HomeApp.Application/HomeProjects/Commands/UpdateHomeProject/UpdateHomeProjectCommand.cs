using MediatR;

namespace HomeApp.Application.HomeProjects.Commands;

public record UpdateHomeProjectCommand(
    Guid Id,
    string Title,
    string? Description,
    decimal? Budget,
    DateOnly? StartDate
) : IRequest;
