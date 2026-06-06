using MediatR;

namespace Market.Application.Modules.Review.Commands.DeleteReview
{
    public class DeleteReviewCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
