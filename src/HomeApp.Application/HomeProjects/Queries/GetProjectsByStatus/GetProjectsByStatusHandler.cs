using HomeApp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeApp.Application.HomeProjects.Queries;

public class GetProjectsByStatusHandler(IAppDbContext dbContext) : IRequestHandler<GetProjectsByStatusQuery, List<HomeProjectDto>>
{
    public async Task<List<HomeProjectDto>> Handle(GetProjectsByStatusQuery request, CancellationToken cancellationToken)
    {
        return await dbContext.HomeProjects
            .Where(p => p.Status == request.Status)
            .Select(p => new HomeProjectDto(p.Id, p.Title, p.Description, p.Status, p.Budget, p.StartDate, p.CompletedDate))
            .ToListAsync(cancellationToken);
    }
}
