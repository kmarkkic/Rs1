using MediatR;
using Market.Application.Abstractions;
using Market.Application.UdomiMe_DTO;
using Microsoft.EntityFrameworkCore;

namespace Market.Application.Modules.AnimalHealthRecord.Queries.GetHealthRecordsByAnimal
{
    public class GetHealthRecordsByAnimalQueryHandler : IRequestHandler<GetHealthRecordsByAnimalQuery, List<AnimalHealthRecordDTO>>
    {
        private readonly IAppDbContext _context;

        public GetHealthRecordsByAnimalQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<List<AnimalHealthRecordDTO>> Handle(GetHealthRecordsByAnimalQuery request, CancellationToken cancellationToken)
        {
            return await _context.AnimalHealthRecords
                .Where(r => r.AnimalId == request.AnimalId && !r.IsDeleted)
                .OrderByDescending(r => r.Date)
                .Select(r => new AnimalHealthRecordDTO
                {
                    Id = (int)r.Id,
                    AnimalId = r.AnimalId,
                    Description = r.Description,
                    Date = r.Date,
                    VetName = r.VetName
                })
                .ToListAsync(cancellationToken);
        }
    }
}
