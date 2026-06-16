using HomeApp.Application.Common.Interfaces;
using MediatR;

namespace HomeApp.Application.FamilyMembers.Commands;

public class DeleteFamilyMemberHandler(IAppDbContext dbContext) : IRequestHandler<DeleteFamilyMemberCommand>
{
    public async Task Handle(DeleteFamilyMemberCommand request, CancellationToken cancellationToken)
    {
        var member = await dbContext.FamilyMembers.FindAsync([request.Id], cancellationToken);

        if (member is null)
            return;

        dbContext.FamilyMembers.Remove(member);
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
