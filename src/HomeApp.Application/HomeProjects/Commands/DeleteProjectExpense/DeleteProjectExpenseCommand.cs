using MediatR;

namespace HomeApp.Application.HomeProjects.Commands;

public record DeleteProjectExpenseCommand(Guid Id) : IRequest;
