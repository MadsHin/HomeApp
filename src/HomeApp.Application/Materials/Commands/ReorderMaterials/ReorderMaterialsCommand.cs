using MediatR;

namespace HomeApp.Application.Materials.Commands;

public record ReorderMaterialsCommand(List<Guid> OrderedIds) : IRequest;
