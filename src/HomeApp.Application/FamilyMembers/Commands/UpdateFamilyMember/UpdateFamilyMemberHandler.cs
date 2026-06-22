using HomeApp.Application.Common.Interfaces;
using MediatR;

namespace HomeApp.Application.FamilyMembers.Commands;

public class UpdateFamilyMemberHandler(IAppDbContext dbContext) : IRequestHandler<UpdateFamilyMemberCommand>
{
    public async Task Handle(UpdateFamilyMemberCommand request, CancellationToken cancellationToken)
    {
        var member = await dbContext.FamilyMembers.FindAsync([request.Id], cancellationToken);

        if (member is null)
            return;

        member.Name = request.Name;
        member.Birthday = request.Birthday;
        member.PhoneNumber = request.PhoneNumber;

        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
