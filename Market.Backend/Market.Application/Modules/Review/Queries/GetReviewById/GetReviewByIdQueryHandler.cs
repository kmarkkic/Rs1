using MediatR;
using Market.Application.Abstractions;
using Market.Application.UdomiMe_DTO;
using Microsoft.EntityFrameworkCore;

namespace Market.Application.Modules.Review.Queries.GetReviewById
{
    public class GetReviewByIdQueryHandler : IRequestHandler<GetReviewByIdQuery, ReviewDTO>
    {
        private readonly IAppDbContext _context;

        public GetReviewByIdQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<ReviewDTO> Handle(GetReviewByIdQuery request, CancellationToken cancellationToken)
        {
            var review = await _context.Reviews
                .Where(r => r.Id == request.Id && !r.IsDeleted)
                .Select(r => new ReviewDTO
                {
                    Id = (int)r.Id,
                    UserId = r.UserId,
                    ShelterId = r.ShelterId,
                    Rating = r.Rating,
                    Comment = r.Comment
                })
                .FirstOrDefaultAsync(cancellationToken);

            if (review == null)
                throw new Exception($"Review with ID {request.Id} not found.");

            return review;
        }
    }
}
