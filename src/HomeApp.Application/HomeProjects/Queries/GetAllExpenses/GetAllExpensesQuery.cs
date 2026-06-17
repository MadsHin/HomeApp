using MediatR;

namespace HomeApp.Application.HomeProjects.Queries;

public record GetAllExpensesQuery : IRequest<List<AllExpenseDto>>;
