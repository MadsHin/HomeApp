namespace HomeApp.Application.FamilyMembers.Queries;

public record FamilyMemberDto(
    Guid Id,
    string Name,
    DateOnly? Birthday,
    string? PhoneNumber
);
