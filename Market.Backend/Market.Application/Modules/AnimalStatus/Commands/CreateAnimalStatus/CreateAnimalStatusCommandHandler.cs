using MediatR;
using Market.Application.Abstractions;

namespace Market.Application.Modules.AnimalStatus.Commands.CreateAnimalStatus
{
    public class CreateAnimalStatusCommandHandler : IRequestHandler<CreateAnimalStatusCommand, int>
    {
        private readonly IAppDbContext _context;

        public CreateAnimalStatusCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateAnimalStatusCommand request, CancellationToken cancellationToken)
        {
            var animalStatus = new Domain.Entities.UdomiMe.AnimalStatus
            {
                Name = request.Name
            };

            _context.AnimalStatuses.Add(animalStatus);
            await _context.SaveChangesAsync(cancellationToken);

            return (int)animalStatus.Id;
        }
    }
}