namespace Market.Application.Modules.Favourites.Commands.AddFavourite
{
    public class AddFavouriteCommandHandler : IRequestHandler<AddFavouriteCommand, int>
    {
        private readonly IAppDbContext _context;

        public AddFavouriteCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(AddFavouriteCommand request, CancellationToken cancellationToken)
        {
            var exists = await _context.Favourites
                .AnyAsync(x => x.UserId == request.UserId && x.AnimalId == request.AnimalId && !x.IsDeleted, cancellationToken);

            if (exists)
                throw new Exception("Animal is already in favourites");

            var favourite = new Domain.Entities.UdomiMe.Favourite
            {
                UserId = request.UserId,
                AnimalId = request.AnimalId
            };

            _context.Favourites.Add(favourite);
            await _context.SaveChangesAsync(cancellationToken);

            return (int)favourite.Id;
        }
    }
}