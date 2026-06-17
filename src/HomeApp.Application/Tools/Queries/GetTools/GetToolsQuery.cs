using MediatR;

namespace HomeApp.Application.Tools.Queries;

public record GetToolsQuery : IRequest<List<ToolDto>>;
