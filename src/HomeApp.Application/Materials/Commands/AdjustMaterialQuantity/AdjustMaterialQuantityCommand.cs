using MediatR;

namespace HomeApp.Application.Materials.Commands;

public record AdjustMaterialQuantityCommand(Guid Id, decimal Delta) : IRequest;
