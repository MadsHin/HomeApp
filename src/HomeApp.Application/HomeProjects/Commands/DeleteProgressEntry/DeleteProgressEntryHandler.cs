using HomeApp.Application.Common.Interfaces;
using MediatR;

namespace HomeApp.Application.HomeProjects.Commands;

public class DeleteProgressEntryHandler(IAppDbContext dbContext) : IRequestHandler<DeleteProgressEntryCommand>
{
    public async Task Handle(DeleteProgressEntryCommand request, CancellationToken cancellationToken)
    {
        var entry = await dbContext.ProgressEntries.FindAsync([request.Id], cancellationToken);

        if (entry is null)
            return;

        dbContext.ProgressEntries.Remove(entry);
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
