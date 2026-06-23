using HomeApp.Domain.Entities;
using MediatR;

namespace HomeApp.Application.HomeProjects.Commands;

public record AddProjectExpenseCommand(
    Guid HomeProjectId,
    string Description,
    decimal Amount,
    DateOnly Date,
    ExpenseCategory Category
) : IRequest;
