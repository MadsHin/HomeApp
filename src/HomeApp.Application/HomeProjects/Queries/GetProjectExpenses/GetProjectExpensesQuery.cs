using MediatR;

namespace HomeApp.Application.HomeProjects.Queries;

public record GetProjectExpensesQuery(Guid ProjectId) : IRequest<List<ProjectExpenseDto>>;
