using MediatR;

namespace HomeApp.Application.HomeProjects.Queries;

public record GetProjectPhotosQuery(Guid ProjectId) : IRequest<List<PhotoDto>>;
