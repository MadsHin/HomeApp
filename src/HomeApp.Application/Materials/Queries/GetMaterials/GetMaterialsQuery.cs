using MediatR;

namespace HomeApp.Application.Materials.Queries;

public record GetMaterialsQuery() : IRequest<List<MaterialDto>>;
