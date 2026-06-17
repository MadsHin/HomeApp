using HomeApp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeApp.Application.HomeProjects.Queries;

public class GetAllPhotosHandler(IAppDbContext dbContext)
    : IRequestHandler<GetAllPhotosQuery, List<PhotoDto>>
{
    public async Task<List<PhotoDto>> Handle(
        GetAllPhotosQuery request, CancellationToken cancellationToken)
    {
        return await dbContext.Photos
            .OrderBy(p => p.HomeProject.Title)
            .ThenByDescending(p => p.UploadedAt)
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
