using MediatR;
using Market.Application.Abstractions;
using Market.Application.UdomiMe_DTO;
using Microsoft.EntityFrameworkCore;

namespace Market.Application.Modules.Review.Queries.GetReviewsByShelter
{
    public class GetReviewsByShelterQueryHandler : IRequestHandler<GetReviewsByShelterQuery, List<ReviewDTO>>
    {
        private readonly IAppDbContext _context;

        public GetReviewsByShelterQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ReviewDTO>> Handle(GetReviewsByShelterQuery request, CancellationToken cancellationToken)
        {
            return await _context.Reviews
                .Where(r => r.ShelterId == request.ShelterId && !r.IsDeleted)
                .Select(r => new ReviewDTO
                {
                    Id = (int)r.Id,
                    UserId = r.UserId,
                    ShelterId = r.ShelterId,
                    Rating = r.Rating,
                    Comment = r.Comment
                })
                .ToListAsync(cancellationToken);
        }
    }
}
