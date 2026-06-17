using HomeApp.Domain.Entities;
using MediatR;

namespace HomeApp.Application.Tools.Commands;

public record UpdateToolCommand(
    Guid Id,
    string Name,
    string? Category,
    string? Icon,
    string? Notes,
    ToolStatus Status,
    string? StatusNote
) : IRequest;
