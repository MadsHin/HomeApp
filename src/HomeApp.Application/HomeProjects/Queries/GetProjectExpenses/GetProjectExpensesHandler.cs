using HomeApp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeApp.Application.HomeProjects.Queries;

public class GetProjectExpensesHandler(IAppDbContext dbContext)
    : IRequestHandler<GetProjectExpensesQuery, List<ProjectExpenseDto>>
{
    public async Task<List<ProjectExpenseDto>> Handle(
        GetProjectExpensesQuery request, CancellationToken cancellationToken)
    {
        return await dbContext.ProjectExpenses
            .Where(e => e.HomeProjectId == request.ProjectId)
            .OrderByDescending(e => e.Date)
            .ThenByDescending(e => e.CreatedAt)
            .Select(e => new ProjectExpenseDto(e.Id, e.Description, e.Amount, e.Date))
            .ToListAsync(cancellationToken);
    }
}
