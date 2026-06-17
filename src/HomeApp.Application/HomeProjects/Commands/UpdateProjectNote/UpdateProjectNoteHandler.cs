using HomeApp.Application.Common.Interfaces;
using HomeApp.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeApp.Application.HomeProjects.Commands;

public class UpdateProjectNoteHandler(IAppDbContext dbContext) : IRequestHandler<UpdateProjectNoteCommand>
{
    public async Task Handle(UpdateProjectNoteCommand request, CancellationToken cancellationToken)
    {
        ProjectNote? note = await dbContext.ProjectNotes
            .Include(n => n.NotePhotos)
            .FirstOrDefaultAsync(n => n.Id == request.Id, cancellationToken);

        if (note is null) return;

        note.Content = request.Content;
        note.UpdatedAt = DateTime.UtcNow;

        note.NotePhotos.Clear();
        foreach (Guid photoId in request.PhotoIds)
            note.NotePhotos.Add(new ProjectNotePhoto { NoteId = note.Id, PhotoId = photoId });

        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
