using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Market.Application.Modules.Breeds.Queries;
using Market.Application.UdomiMe_DTO;

namespace Market.Application.Modules.Breeds.Queries.GetBreeds
{
    public class GetBreedsQueryHandler : IRequestHandler<GetBreedsQuery, IReadOnlyList<BreedsDTO>>
    {


        private readonly IAppDbContext _context;
        public GetBreedsQueryHandler(IAppDbContext context)
        {
            _context = context;
        }   


        public async Task<IReadOnlyList<BreedsDTO>> Handle(GetBreedsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Breeds
                .Where(b => b.IsDeleted == false)
                .Select(c => new BreedsDTO
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToListAsync(cancellationToken);
        }
    }
}
