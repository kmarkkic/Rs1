using MediatR;
using Market.Application.Abstractions;
using Market.Application.UdomiMe_DTO;
using Microsoft.EntityFrameworkCore;

namespace Market.Application.Modules.AnimalHealthRecord.Queries.GetHealthRecordById
{
    public class GetHealthRecordByIdQueryHandler : IRequestHandler<GetHealthRecordByIdQuery, AnimalHealthRecordDTO>
    {
        private readonly IAppDbContext _context;

        public GetHealthRecordByIdQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<AnimalHealthRecordDTO> Handle(GetHealthRecordByIdQuery request, CancellationToken cancellationToken)
        {
            var record = await _context.AnimalHealthRecords
                .Where(r => r.Id == request.Id && !r.IsDeleted)
                .Select(r => new AnimalHealthRecordDTO
                {
                    Id = (int)r.Id,
                    AnimalId = r.AnimalId,
                    Description = r.Description,
                    Date = r.Date,
                    VetName = r.VetName
                })
                .FirstOrDefaultAsync(cancellationToken);

            if (record == null)
                throw new Exception($"AnimalHealthRecord with ID {request.Id} not found.");

            return record;
        }
    }
}
