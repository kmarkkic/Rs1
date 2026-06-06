using MediatR;
using Market.Application.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Market.Application.Modules.AnimalHealthRecord.Commands.DeleteAnimalHealthRecord
{
    public class DeleteAnimalHealthRecordCommandHandler : IRequestHandler<DeleteAnimalHealthRecordCommand, Unit>
    {
        private readonly IAppDbContext _context;

        public DeleteAnimalHealthRecordCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteAnimalHealthRecordCommand request, CancellationToken cancellationToken)
        {
            var record = await _context.AnimalHealthRecords
                .FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted, cancellationToken);

            if (record == null)
                throw new Exception($"AnimalHealthRecord with ID {request.Id} not found.");

            record.IsDeleted = true;
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
