using HomeApp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeApp.Application.HomeProjects.Queries;

public class GetAllExpensesHandler(IAppDbContext dbContext) : IRequestHandler<GetAllExpensesQuery, List<AllExpenseDto>>
{
    public async Task<List<AllExpenseDto>> Handle(GetAllExpensesQuery request, CancellationToken cancellationToken)
    {
        return await dbContext.ProjectExpenses
            .Join(dbContext.HomeProjects, e => e.HomeProjectId, p => p.Id,
                (e, p) => new AllExpenseDto(e.Id, p.Id, p.Title, e.Description, e.Amount, e.Date))
            .OrderByDescending(e => e.Date)
            .ToListAsync(cancellationToken);
    }
}
