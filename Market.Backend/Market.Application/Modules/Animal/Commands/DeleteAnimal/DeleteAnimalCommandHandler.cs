namespace Market.Application.Modules.Animal.Commands.DeleteAnimal
{
    public class DeleteAnimalCommandHandler : IRequestHandler<DeleteAnimalCommand>
    {
        private readonly IAppDbContext _context;

        public DeleteAnimalCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task Handle(DeleteAnimalCommand request, CancellationToken cancellationToken)
        {
            var animal = await _context.Animals
                .FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted, cancellationToken);

            if (animal == null)
                throw new Exception("Animal not found");

            animal.IsDeleted = true;

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}