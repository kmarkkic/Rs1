using MediatR;
using Market.Application.Abstractions;

namespace Market.Application.Modules.AnimalHealthRecord.Commands.UpdateAnimalHealthRecord
{
    public class UpdateAnimalHealthRecordCommandHandler : IRequestHandler<UpdateAnimalHealthRecordCommand, Unit>
    {
        private readonly IAppDbContext _context;

        public UpdateAnimalHealthRecordCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateAnimalHealthRecordCommand request, CancellationToken cancellationToken)
        {
            var record = await _context.AnimalHealthRecords.FindAsync(request.Id);

            if (record == null)
                throw new Exception($"AnimalHealthRecord with ID {request.Id} not found.");

            record.Description = request.Description;
            record.Date = request.Date;
            record.VetName = request.VetName;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
