using MediatR;
using Market.Application.Abstractions;

namespace Market.Application.Modules.AnimalHealthRecord.Commands.CreateAnimalHealthRecord
{
    public class CreateAnimalHealthRecordCommandHandler : IRequestHandler<CreateAnimalHealthRecordCommand, int>
    {
        private readonly IAppDbContext _context;

        public CreateAnimalHealthRecordCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateAnimalHealthRecordCommand request, CancellationToken cancellationToken)
        {
            var record = new Domain.Entities.UdomiMe.AnimalHealthRecord
            {
                AnimalId = request.AnimalId,
                Description = request.Description,
                Date = request.Date,
                VetName = request.VetName
            };

            _context.AnimalHealthRecords.Add(record);
            await _context.SaveChangesAsync(cancellationToken);

            return (int)record.Id;
        }
    }
}
