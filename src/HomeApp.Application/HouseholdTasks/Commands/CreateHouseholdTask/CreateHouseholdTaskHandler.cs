
using HomeApp.Application.Common.Interfaces;
using HomeApp.Domain.Entities;
using MediatR;

namespace HomeApp.Application.HouseholdTasks.Commands;


public class CreateHouseholdTaskHandler(IAppDbContext dbContext) : IRequestHandler<CreateHouseholdTaskCommand, Guid>
{
    public async Task<Guid> Handle(CreateHouseholdTaskCommand request, CancellationToken cancellationToken)
    {
        HouseholdTask task = new()
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            AssignedMemberId = request.AssignedMemberId,
            Description = request.Description,
            DueDate = request.DueDate,
            Recurrence = request.Recurrence
        };

        dbContext.HouseholdTasks.Add(task);
        await dbContext.SaveChangesAsync(cancellationToken);
        return task.Id;
            
        
    }
}