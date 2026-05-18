namespace Market.Application.Modules.Favourites.Commands.AddFavourite
{
    public record AddFavouriteCommand(
        int UserId,
        int AnimalId
    ) : IRequest<int>;
}