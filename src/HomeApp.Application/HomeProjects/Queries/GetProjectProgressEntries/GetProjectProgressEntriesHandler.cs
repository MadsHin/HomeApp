using HomeApp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeApp.Application.HomeProjects.Queries;

public class GetProjectProgressEntriesHandler(IAppDbContext dbContext)
    : IRequestHandler<GetProjectProgressEntriesQuery, List<ProgressEntryDto>>
{
    public async Task<List<ProgressEntryDto>> Handle(
        GetProjectProgressEntriesQuery request, CancellationToken cancellationToken)
    {
        return await dbContext.ProgressEntries
            .Where(e => e.HomeProjectId == request.ProjectId)
            .OrderByDescending(e => e.Date)
            .Select(e => new ProgressEntryDto(e.Id, e.Date, e.Note))
            .ToListAsync(cancellationToken);
    }
}
