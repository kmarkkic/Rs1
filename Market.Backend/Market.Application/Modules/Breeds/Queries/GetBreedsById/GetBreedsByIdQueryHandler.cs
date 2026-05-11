using Market.Application.UdomiMe_DTO;
using Microsoft.EntityFrameworkCore; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Market.Application.Modules.Breeds.Queries.GetBreedsById
{
    public class GetBreedsByIdQueryHandler : IRequestHandler<GetBreedByIdQuery, BreedsDTO>
    {
        private readonly IAppDbContext _context;

        public GetBreedsByIdQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<BreedsDTO> Handle(GetBreedByIdQuery request, CancellationToken ct)
        {
            var result = await _context.Breeds
                .Where(x => x.Id == request.Id && !x.IsDeleted)
                .Select(x => new BreedsDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    AnimalTypeId = x.AnimalTypeId,
                    AnimalType = new AnimalTypesDTO
                    {
                        Id = x.AnimalType.Id,
                        Name = x.AnimalType.Name
                    }
                })
                .FirstOrDefaultAsync(ct); // Promijenjeno iz FirstOrDefault u FirstOrDefaultAsync

            return result;
        }
    }
}