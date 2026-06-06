using MediatR;
using Market.Application.UdomiMe_DTO;

namespace Market.Application.Modules.Review.Queries.GetReviewsByShelter
{
    public class GetReviewsByShelterQuery : IRequest<List<ReviewDTO>>
    {
        public int ShelterId { get; set; }
    }
}
