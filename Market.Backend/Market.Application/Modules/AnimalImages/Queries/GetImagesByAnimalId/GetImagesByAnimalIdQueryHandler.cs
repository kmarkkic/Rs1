using MediatR;
using Market.Application.Abstractions;
using Market.Application.UdomiMe_DTO;
using Microsoft.EntityFrameworkCore;

namespace Market.Application.Modules.AnimalImages.Queries.GetImagesByAnimalId
{
    public class GetImagesByAnimalIdQueryHandler : IRequestHandler<GetImagesByAnimalIdQuery, List<AnimalImagesDTO>>
    {
        private readonly IAppDbContext _context;

        public GetImagesByAnimalIdQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<List<AnimalImagesDTO>> Handle(GetImagesByAnimalIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.AnimalImages
                .Where(a => a.AnimalId == request.AnimalId)
                .Select(a => new AnimalImagesDTO
                {
                    Id = a.Id,
                    AnimalId = a.AnimalId,
                    ImageUrl = a.ImageUrl
                })
                .ToListAsync(cancellationToken);
        }
    }
}