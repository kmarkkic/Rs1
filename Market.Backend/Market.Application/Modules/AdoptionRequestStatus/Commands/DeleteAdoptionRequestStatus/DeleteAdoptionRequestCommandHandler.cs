using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Modules.AdoptionRequestStatus.Commands.DeleteAdoptionRequestStatus
{
    public class DeleteAdoptionRequestStatusCommandHandler : IRequestHandler<DeleteAdoptionRequestStatusCommand>
    {
        private readonly IAppDbContext _context;

        public DeleteAdoptionRequestStatusCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task Handle(DeleteAdoptionRequestStatusCommand request, CancellationToken cancellationToken)
        {
            var result = await _context.AdoptionRequestStatuses.FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted, cancellationToken);
            if (result == null) {

                throw new Exception("AdoptionRequestStatus not found");
            }

            result.IsDeleted = true;
            await _context.SaveChangesAsync(cancellationToken);

            
        }

       
    }
}