namespace HomeApp.Domain.Entities;

public class FamilyMember
{
    public Guid Id {get; set;}
    public required string Name {get; set;}
    public DateOnly? Birthday {get; set;}
    public string? PhoneNumber {get; set;}
}