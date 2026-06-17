using HomeApp.Application.Common.Interfaces;
using HomeApp.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeApp.Application.HomeProjects.Commands;

public class UpdatePhotoCaptionHandler(IAppDbContext dbContext) : IRequestHandler<UpdatePhotoCaptionCommand>
{
    public async Task Handle(UpdatePhotoCaptionCommand request, CancellationToken cancellationToken)
    {
        Photo? photo = await dbContext.Photos
            .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

        if (photo is null) return;

        photo.Caption = string.IsNullOrWhiteSpace(request.Caption) ? null : request.Caption;
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
