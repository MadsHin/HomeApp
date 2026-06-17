using MediatR;

namespace HomeApp.Application.HomeProjects.Queries;

public record GetAllPhotosQuery : IRequest<List<PhotoDto>>;
