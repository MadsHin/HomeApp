using MediatR;

namespace HomeApp.Application.FamilyMembers.Commands;

public record UpdateFamilyMemberCommand(
    Guid Id,
    string Name,
    DateOnly? Birthday,
    string? PhoneNumber
) : IRequest;
