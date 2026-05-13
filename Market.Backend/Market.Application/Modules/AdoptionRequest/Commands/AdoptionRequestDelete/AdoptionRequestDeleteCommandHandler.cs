using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Modules.AdoptionRequest.Commands.AdoptionRequestDelete
{
    public class AdoptionRequestDeleteCommandHandler : IRequestHandler<AdoptionRequestDeleteCommand>
    {
        private readonly IAppDbContext _context;

        public AdoptionRequestDeleteCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task Handle(AdoptionRequestDeleteCommand request, CancellationToken cancellationToken)
        {
            var result = await _context.AdoptionRequests.FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted, cancellationToken);
            if (result == null)
            {
                throw new Exception("Adoption request is deleted");
            }
            result.IsDeleted = true;
            await _context.SaveChangesAsync(cancellationToken);
             
        }
    }
}   