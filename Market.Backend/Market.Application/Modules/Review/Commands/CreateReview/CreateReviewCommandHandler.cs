using MediatR;
using Market.Application.Abstractions;

namespace Market.Application.Modules.Review.Commands.CreateReview
{
    public class CreateReviewCommandHandler : IRequestHandler<CreateReviewCommand, int>
    {
        private readonly IAppDbContext _context;

        public CreateReviewCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
        {
            var review = new Domain.Entities.UdomiMe.Review
            {
                UserId = request.UserId,
                ShelterId = request.ShelterId,
                Rating = request.Rating,
                Comment = request.Comment
            };

            _context.Reviews.Add(review);
            await _context.SaveChangesAsync(cancellationToken);

            return (int)review.Id;
        }
    }
}
