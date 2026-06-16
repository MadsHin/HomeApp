using MediatR;

namespace HomeApp.Application.Materials.Queries;

public record GetMaterialByIdQuery(Guid Id) : IRequest<MaterialDto?>;
