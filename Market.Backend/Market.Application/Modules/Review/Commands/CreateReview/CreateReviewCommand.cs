using MediatR;

namespace Market.Application.Modules.Review.Commands.CreateReview
{
    public class CreateReviewCommand : IRequest<int>
    {
        public int UserId { get; set; }
        public int ShelterId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
    }
}
