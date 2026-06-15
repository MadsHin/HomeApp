using HomeApp.Domain.Enums;
using HomeApp.Domain.Entities;

namespace HomeApp.Domain.Entities;

public class HouseholdTask
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }
    public DateOnly? DueDate { get; set; }
    public bool IsCompleted { get; set; }
    public Recurrence Recurrence { get; set; }

    public Guid? AssignedMemberId { get; set; }
    public FamilyMember? AssignedMember { get; set; }
}
