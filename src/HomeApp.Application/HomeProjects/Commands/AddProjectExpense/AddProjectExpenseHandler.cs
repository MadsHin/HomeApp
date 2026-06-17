using HomeApp.Application.Common.Interfaces;
using HomeApp.Domain.Entities;
using MediatR;

namespace HomeApp.Application.HomeProjects.Commands;

public class AddProjectExpenseHandler(IAppDbContext dbContext) : IRequestHandler<AddProjectExpenseCommand>
{
    public async Task Handle(AddProjectExpenseCommand request, CancellationToken cancellationToken)
    {
        dbContext.ProjectExpenses.Add(new ProjectExpense
        {
            Id = Guid.NewGuid(),
            HomeProjectId = request.HomeProjectId,
            Description = request.Description,
            Amount = request.Amount,
            Date = request.Date,
            CreatedAt = DateTime.UtcNow
        });

        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
