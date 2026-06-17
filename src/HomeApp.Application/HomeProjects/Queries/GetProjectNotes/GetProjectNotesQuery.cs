using MediatR;

namespace HomeApp.Application.HomeProjects.Queries;

public record GetProjectNotesQuery(Guid ProjectId) : IRequest<List<ProjectNoteDto>>;
