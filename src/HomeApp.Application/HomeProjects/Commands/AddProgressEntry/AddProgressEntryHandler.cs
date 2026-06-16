using HomeApp.Application.Common.Interfaces;
using HomeApp.Domain.Entities;
using MediatR;

namespace HomeApp.Application.HomeProjects.Commands;

public class AddProgressEntryHandler(IAppDbContext dbContext) : IRequestHandler<AddProgressEntryCommand, Guid>
{
    public async Task<Guid> Handle(AddProgressEntryCommand request, CancellationToken cancellationToken)
    {
        var entry = new ProgressEntry
        {
            Id = Guid.NewGuid(),
            HomeProjectId = request.HomeProjectId,
            Date = request.Date,
            Note = request.Note
        };

        dbContext.ProgressEntries.Add(entry);
        await dbContext.SaveChangesAsync(cancellationToken);
        return entry.Id;
    }
}
