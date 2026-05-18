namespace Market.Application.Modules.Favourites.Commands.DeleteFavourite
{
    public class DeleteFavouriteCommandHandler : IRequestHandler<DeleteFavouriteCommand>
    {
        private readonly IAppDbContext _context;

        public DeleteFavouriteCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task Handle(DeleteFavouriteCommand request, CancellationToken cancellationToken)
        {
            var favourite = await _context.Favourites
                .FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted, cancellationToken);

            if (favourite == null)
                throw new Exception("Favourite not found");

            favourite.IsDeleted = true;

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}