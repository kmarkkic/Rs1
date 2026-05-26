using MediatR;
using Market.Application.Abstractions;

namespace Market.Application.Modules.AnimalImages.Commands.DeleteAnimalImage
{
    public class DeleteAnimalImageCommandHandler : IRequestHandler<DeleteAnimalImageCommand, Unit>
    {
        private readonly IAppDbContext _context;

        public DeleteAnimalImageCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteAnimalImageCommand request, CancellationToken cancellationToken)
        {
            var animalImage = await _context.AnimalImages.FindAsync(request.Id);

            if (animalImage == null)
                throw new Exception($"AnimalImage with ID {request.Id} not found.");

            _context.AnimalImages.Remove(animalImage);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}