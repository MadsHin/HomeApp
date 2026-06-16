using MediatR;

namespace HomeApp.Application.HomeProjects.Queries;

public record GetHomeProjectByIdQuery(Guid Id) : IRequest<HomeProjectDto?>;
