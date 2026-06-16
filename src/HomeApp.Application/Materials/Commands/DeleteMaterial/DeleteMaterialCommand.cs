using MediatR;

namespace HomeApp.Application.Materials.Commands;

public record DeleteMaterialCommand(Guid Id) : IRequest;
