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
                (e, p) => new { e, p })
            .OrderByDescending(x => x.e.Date)
            .Select(x => new AllExpenseDto(x.e.Id, x.p.Id, x.p.Title, x.e.Description, x.e.Amount, x.e.Date, x.e.Category))
            .ToListAsync(cancellationToken);
    }
}
