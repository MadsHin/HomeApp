using HomeApp.Application.Common.Interfaces;
using HomeApp.Domain.Entities;
using MediatR;

namespace HomeApp.Application.HomeProjects.Commands;

public class AddContactToProjectHandler(IAppDbContext dbContext) : IRequestHandler<AddContactToProjectCommand>
{
    public async Task Handle(AddContactToProjectCommand request, CancellationToken cancellationToken)
    {
        var join = new HomeProjectContact
        {
            HomeProjectId = request.HomeProjectId,
            HomeProject = null!,
            ContactId = request.ContactId,
            Contact = null!,
            Role = request.Role
        };

        dbContext.HomeProjectContacts.Add(join);
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
