using Market.Application.UdomiMe_DTO;

namespace Market.Application.Modules.Favourites.Queries.GetFavouritesByUser
{
    public record GetFavouritesByUserQuery(int UserId) : IRequest<List<FavouritesDTO>>;
}