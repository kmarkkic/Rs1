using MediatR;
using Market.Application.Abstractions;
using Market.Application.UdomiMe_DTO;
using Microsoft.EntityFrameworkCore;

namespace Market.Application.Modules.AnimalStatus.Queries.GetAnimalStatusById
{
    public class GetAnimalStatusByIdQueryHandler : IRequestHandler<GetAnimalStatusByIdQuery, AnimalStatusDTO>
    {
        private readonly IAppDbContext _context;

        public GetAnimalStatusByIdQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<AnimalStatusDTO> Handle(GetAnimalStatusByIdQuery request, CancellationToken cancellationToken)
        {
            var animalStatus = await _context.AnimalStatuses
                .Where(a => a.Id == request.Id)
                .Select(a => new AnimalStatusDTO
                {
                    Id = a.Id,
                    Name = a.Name
                })
                .FirstOrDefaultAsync(cancellationToken);

            if (animalStatus == null)
                throw new Exception($"AnimalStatus with ID {request.Id} not found.");

            return animalStatus;
        }
    }
}