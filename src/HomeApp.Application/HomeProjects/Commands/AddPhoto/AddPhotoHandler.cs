using HomeApp.Application.Common.Interfaces;
using HomeApp.Domain.Entities;
using MediatR;

namespace HomeApp.Application.HomeProjects.Commands;

public class AddPhotoHandler(IAppDbContext dbContext) : IRequestHandler<AddPhotoCommand>
{
    public async Task Handle(AddPhotoCommand request, CancellationToken cancellationToken)
    {
        dbContext.Photos.Add(new Photo
        {
            Id = Guid.NewGuid(),
            HomeProjectId = request.HomeProjectId,
            FileName = request.FileName,
            StoredFileName = request.StoredFileName,
            Caption = request.Caption,
            UploadedAt = DateTime.UtcNow
        });

        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
