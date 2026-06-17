using HomeApp.Application.Common.Interfaces;
using HomeApp.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeApp.Application.HomeProjects.Commands;

public class DeletePhotoHandler(IAppDbContext dbContext) : IRequestHandler<DeletePhotoCommand, string?>
{
    public async Task<string?> Handle(DeletePhotoCommand request, CancellationToken cancellationToken)
    {
        Photo? photo = await dbContext.Photos
            .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

        if (photo is null) return null;

        string storedFileName = photo.StoredFileName;
        dbContext.Photos.Remove(photo);
        await dbContext.SaveChangesAsync(cancellationToken);
        return storedFileName;
    }
}
