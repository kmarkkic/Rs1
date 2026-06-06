using MediatR;
using Market.Application.UdomiMe_DTO;

namespace Market.Application.Modules.Review.Queries.GetReviewById
{
    public class GetReviewByIdQuery : IRequest<ReviewDTO>
    {
        public int Id { get; set; }
    }
}
