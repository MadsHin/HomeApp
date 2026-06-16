using MediatR;

namespace HomeApp.Application.HomeProjects.Commands;

public record AddContactToProjectCommand(
    Guid HomeProjectId,
    Guid ContactId,
    string? Role
) : IRequest;
