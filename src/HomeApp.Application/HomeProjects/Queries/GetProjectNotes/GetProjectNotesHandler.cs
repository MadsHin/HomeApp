using HomeApp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeApp.Application.HomeProjects.Queries;

public class GetProjectNotesHandler(IAppDbContext dbContext)
    : IRequestHandler<GetProjectNotesQuery, List<ProjectNoteDto>>
{
    public async Task<List<ProjectNoteDto>> Handle(
        GetProjectNotesQuery request, CancellationToken cancellationToken)
    {
        return await dbContext.ProjectNotes
            .Where(n => n.HomeProjectId == request.ProjectId)
            .OrderByDescending(n => n.CreatedAt)
            .Select(n => new ProjectNoteDto(
                n.Id,
                n.Content,
                n.CreatedAt,
                n.UpdatedAt,
                n.NotePhotos.Select(np => new PhotoDto(
                    np.Photo.Id,
                    np.Photo.StoredFileName,
                    np.Photo.Caption,
                    np.Photo.HomeProject.Title,
                    np.Photo.HomeProjectId,
                    np.Photo.UploadedAt)).ToList()))
            .ToListAsync(cancellationToken);
    }
}
