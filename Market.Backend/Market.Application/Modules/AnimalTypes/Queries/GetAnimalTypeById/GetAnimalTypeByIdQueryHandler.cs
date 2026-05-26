using MediatR;
using Market.Application.Abstractions;
using Market.Application.UdomiMe_DTO;
using Microsoft.EntityFrameworkCore;

namespace Market.Application.Modules.AnimalTypes.Queries.GetAnimalTypeById
{
    public class GetAnimalTypeByIdQueryHandler : IRequestHandler<GetAnimalTypeByIdQuery, AnimalTypesDTO>
    {
        private readonly IAppDbContext _context;

        public GetAnimalTypeByIdQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<AnimalTypesDTO> Handle(GetAnimalTypeByIdQuery request, CancellationToken cancellationToken)
        {
            var animalType = await _context.AnimalTypes
                .Where(a => a.Id == request.Id)
                .Select(a => new AnimalTypesDTO
                {
                    Id = a.Id,
                    Name = a.Name
                })
                .FirstOrDefaultAsync(cancellationToken);

            if (animalType == null)
                throw new Exception($"AnimalType with ID {request.Id} not found.");

            return animalType;
        }
    }
}