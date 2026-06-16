using HomeApp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeApp.Application.HomeProjects.Queries;

public class GetProjectContactsHandler(IAppDbContext dbContext)
    : IRequestHandler<GetProjectContactsQuery, List<ProjectContactDto>>
{
    public async Task<List<ProjectContactDto>> Handle(
        GetProjectContactsQuery request, CancellationToken cancellationToken)
    {
        return await dbContext.HomeProjectContacts
            .Where(c => c.HomeProjectId == request.ProjectId)
            .Select(c => new ProjectContactDto(c.ContactId, c.Contact.Name, c.Contact.Phone, c.Role))
            .ToListAsync(cancellationToken);
    }
}
