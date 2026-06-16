using HomeApp.Domain.Enums;
using MediatR;

namespace HomeApp.Application.HomeProjects.Commands;

public record CreateHomeProjectCommand(
    string Title,
    string? Description,
    ProjectStatus Status,
    decimal? Budget,
    DateOnly? StartDate
) : IRequest<Guid>;
