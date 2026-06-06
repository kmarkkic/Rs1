using MediatR;

namespace Market.Application.Modules.Review.Commands.UpdateReview
{
    public class UpdateReviewCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
    }
}
