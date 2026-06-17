using HomeApp.Application.Common.Interfaces;
using HomeApp.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeApp.Application.HomeProjects.Commands;

public class DeleteProjectExpenseHandler(IAppDbContext dbContext) : IRequestHandler<DeleteProjectExpenseCommand>
{
    public async Task Handle(DeleteProjectExpenseCommand request, CancellationToken cancellationToken)
    {
        ProjectExpense? expense = await dbContext.ProjectExpenses
            .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

        if (expense is null) return;

        dbContext.ProjectExpenses.Remove(expense);
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
