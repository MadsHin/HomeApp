using MediatR;

namespace HomeApp.Application.HomeProjects.Queries;

public record GetHomeProjectsQuery() : IRequest<List<HomeProjectDto>>;
