using Market.Application.UdomiMe_DTO.Adoptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Modules.AdoptionRequestStatus.Commands.CreateAdoptionRequestStatus
{
    public class CreateAdoptionRequestStatusCommandHandler : IRequestHandler<CreateAdoptionRequestStatusCommand, AdoptionRequestStatusesDTO>
    {

        IAppDbContext _context;

        public CreateAdoptionRequestStatusCommandHandler(IAppDbContext context)
        {
            _context = context;
        }
        public async Task<AdoptionRequestStatusesDTO> Handle(CreateAdoptionRequestStatusCommand request, CancellationToken cancellationToken)
        {
            var rezultat = new Market.Domain.Entities.UdomiMe.AdoptionRequestStatus
            {
                Name = request.Name
            };

            _context.AdoptionRequestStatuses.Add(rezultat);
            await _context.SaveChangesAsync(cancellationToken);

            return new AdoptionRequestStatusesDTO
            {
                Id = rezultat.Id,
                Name = rezultat.Name
            };
        }
    }
}