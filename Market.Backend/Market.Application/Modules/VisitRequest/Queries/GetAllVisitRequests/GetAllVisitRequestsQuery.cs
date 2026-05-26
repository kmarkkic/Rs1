using MediatR;
using Market.Application.UdomiMe_DTO;

namespace Market.Application.Modules.VisitRequest.Queries.GetAllVisitRequests
{
    public class GetAllVisitRequestsQuery : IRequest<List<VisitRequestDTO>>
    {
    }
}