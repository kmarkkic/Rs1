using MediatR;
using Market.Application.Abstractions;

namespace Market.Application.Modules.Review.Commands.UpdateReview
{
    public class UpdateReviewCommandHandler : IRequestHandler<UpdateReviewCommand, Unit>
    {
        private readonly IAppDbContext _context;

        public UpdateReviewCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
        {
            var review = await _context.Reviews.FindAsync(request.Id);

            if (review == null)
                throw new Exception($"Review with ID {request.Id} not found.");

            review.Rating = request.Rating;
            review.Comment = request.Comment;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
