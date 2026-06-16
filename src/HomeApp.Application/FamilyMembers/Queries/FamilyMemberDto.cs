namespace HomeApp.Application.FamilyMembers.Queries;

public record FamilyMemberDto(
    Guid Id,
    string Name,
    int Age,
    string? PhoneNumber
);
