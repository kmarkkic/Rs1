using MediatR;
using Market.Application.Abstractions;
using Market.Application.UdomiMe_DTO;
using Microsoft.EntityFrameworkCore;

namespace Market.Application.Modules.AnimalTypes.Queries.GetAllAnimalTypes
{
    public class GetAllAnimalTypesQueryHandler : IRequestHandler<GetAllAnimalTypesQuery, List<AnimalTypesDTO>>
    {
        private readonly IAppDbContext _context;

        public GetAllAnimalTypesQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<List<AnimalTypesDTO>> Handle(GetAllAnimalTypesQuery request, CancellationToken cancellationToken)
        {
            return await _context.AnimalTypes
                .Select(a => new AnimalTypesDTO
                {
                    Id = a.Id,
                    Name = a.Name
                })
                .ToListAsync(cancellationToken);
        }
    }
}