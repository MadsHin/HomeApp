using HomeApp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeApp.Application.HomeProjects.Queries;

public class GetProjectPhotosHandler(IAppDbContext dbContext)
    : IRequestHandler<GetProjectPhotosQuery, List<PhotoDto>>
{
    public async Task<List<PhotoDto>> Handle(
        GetProjectPhotosQuery request, CancellationToken cancellationToken)
    {
        return await dbContext.Photos
            .Where(p => p.HomeProjectId == request.ProjectId)
            .OrderByDescending(p => p.UploadedAt)
            .Select(p => new PhotoDto(
                p.Id,
                p.StoredFileName,
                p.Caption,
                p.HomeProject.Title,
                p.HomeProjectId,
                p.UploadedAt))
            .ToListAsync(cancellationToken);
    }
}
