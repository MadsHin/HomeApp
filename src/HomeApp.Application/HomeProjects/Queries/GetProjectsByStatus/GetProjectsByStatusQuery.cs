using HomeApp.Domain.Enums;
using MediatR;

namespace HomeApp.Application.HomeProjects.Queries;

public record GetProjectsByStatusQuery(ProjectStatus Status) : IRequest<List<HomeProjectDto>>;
