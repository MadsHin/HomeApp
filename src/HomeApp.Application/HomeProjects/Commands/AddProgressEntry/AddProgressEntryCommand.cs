using MediatR;

namespace HomeApp.Application.HomeProjects.Commands;

public record AddProgressEntryCommand(
    Guid HomeProjectId,
    DateOnly Date,
    string Note
) : IRequest<Guid>;
