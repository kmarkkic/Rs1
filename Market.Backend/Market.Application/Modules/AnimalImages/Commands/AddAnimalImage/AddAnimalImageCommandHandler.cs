using MediatR;
using Market.Application.Abstractions;

namespace Market.Application.Modules.AnimalImages.Commands.AddAnimalImage
{
    public class AddAnimalImageCommandHandler : IRequestHandler<AddAnimalImageCommand, int>
    {
        private readonly IAppDbContext _context;

        public AddAnimalImageCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(AddAnimalImageCommand request, CancellationToken cancellationToken)
        {
            var animalImage = new Domain.Entities.UdomiMe.AnimalImages
            {
                AnimalId = request.AnimalId,
                ImageUrl = request.ImageUrl
            };

            _context.AnimalImages.Add(animalImage);
            await _context.SaveChangesAsync(cancellationToken);

            return (int)animalImage.Id;
        }
    }
}