using MediatR;

namespace HomeApp.Application.Materials.Queries;

public record GetShoppingListQuery : IRequest<List<ShoppingListItemDto>>;
