using Market.Application.UdomiMe_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Market.Domain.Entities;
using System.Threading.Tasks;

namespace Market.Application.Modules.AdoptionRequest.Commands.AdoptionRequestCreate
{
    public class AdoptionRequestCreateCommandHandler : IRequestHandler<AdoptionRequestCreateCommand, AdoptionRequestDTO>
    {
        private readonly IAppDbContext _context;

        public AdoptionRequestCreateCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<AdoptionRequestDTO> Handle(AdoptionRequestCreateCommand request, CancellationToken cancellationToken)
        {
            var adoptionRequest = new Market.Domain.Entities.UdomiMe.AdoptionRequest
            {
                UserId = request.UserId,
                AnimalId = request.AnimalId,
                Message = request.Message,
                StatusId = request.StatusId
            };

            _context.AdoptionRequests.Add(adoptionRequest);
            await _context.SaveChangesAsync(cancellationToken);

            return new AdoptionRequestDTO
            {
                Id = adoptionRequest.Id,
                UserId = adoptionRequest.UserId,
                AnimalId = adoptionRequest.AnimalId,
                Message = adoptionRequest.Message,
                StatusId = adoptionRequest.StatusId
            };
        }
    }
}       