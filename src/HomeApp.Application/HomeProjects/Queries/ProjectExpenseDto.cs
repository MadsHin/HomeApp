using HomeApp.Domain.Entities;

namespace HomeApp.Application.HomeProjects.Queries;

public record ProjectExpenseDto(
    Guid Id,
    string Description,
    decimal Amount,
    DateOnly Date,
    ExpenseCategory Category
);
