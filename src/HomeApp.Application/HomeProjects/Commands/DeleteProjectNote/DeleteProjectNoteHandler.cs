using HomeApp.Application.Common.Interfaces;
using HomeApp.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeApp.Application.HomeProjects.Commands;

public class DeleteProjectNoteHandler(IAppDbContext dbContext) : IRequestHandler<DeleteProjectNoteCommand>
{
    public async Task Handle(DeleteProjectNoteCommand request, CancellationToken cancellationToken)
    {
        ProjectNote? note = await dbContext.ProjectNotes
            .FirstOrDefaultAsync(n => n.Id == request.Id, cancellationToken);

        if (note is null) return;

        dbContext.ProjectNotes.Remove(note);
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
