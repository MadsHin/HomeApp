namespace HomeApp.Application.Materials.Queries;

public record ShoppingListItemDto(
    Guid MaterialId,
    string Name,
    string? Unit,
    decimal TotalNeeded,
    decimal? InStock,
    decimal Shortfall,
    List<string> ProjectNames,
    decimal? EstimatedCost
);
