using MediatR;
using Market.Application.Abstractions;
using Market.Application.UdomiMe_DTO;
using Microsoft.EntityFrameworkCore;

namespace Market.Application.Modules.AnimalStatus.Queries.GetAllAnimalStatuses
{
    public class GetAllAnimalStatusesQueryHandler : IRequestHandler<GetAllAnimalStatusesQuery, List<AnimalStatusDTO>>
    {
        private readonly IAppDbContext _context;

        public GetAllAnimalStatusesQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<List<AnimalStatusDTO>> Handle(GetAllAnimalStatusesQuery request, CancellationToken cancellationToken)
        {
            return await _context.AnimalStatuses
                .Select(a => new AnimalStatusDTO
                {
                    Id = a.Id,
                    Name = a.Name
                })
                .ToListAsync(cancellationToken);
        }
    }
}