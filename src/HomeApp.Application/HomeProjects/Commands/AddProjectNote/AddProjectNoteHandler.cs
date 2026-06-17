using HomeApp.Application.Common.Interfaces;
using HomeApp.Domain.Entities;
using MediatR;

namespace HomeApp.Application.HomeProjects.Commands;

public class AddProjectNoteHandler(IAppDbContext dbContext) : IRequestHandler<AddProjectNoteCommand>
{
    public async Task Handle(AddProjectNoteCommand request, CancellationToken cancellationToken)
    {
        var note = new ProjectNote
        {
            Id = Guid.NewGuid(),
            HomeProjectId = request.HomeProjectId,
            Content = request.Content,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        foreach (Guid photoId in request.PhotoIds)
            note.NotePhotos.Add(new ProjectNotePhoto { NoteId = note.Id, PhotoId = photoId });

        dbContext.ProjectNotes.Add(note);
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
