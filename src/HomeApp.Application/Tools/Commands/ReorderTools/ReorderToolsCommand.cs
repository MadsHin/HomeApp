using MediatR;

namespace HomeApp.Application.Tools.Commands;

public record ReorderToolsCommand(List<Guid> OrderedIds) : IRequest;
