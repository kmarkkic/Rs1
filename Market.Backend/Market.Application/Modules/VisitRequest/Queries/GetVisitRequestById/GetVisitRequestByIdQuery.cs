using MediatR;
using Market.Application.UdomiMe_DTO;

namespace Market.Application.Modules.VisitRequest.Queries.GetVisitRequestById
{
    public class GetVisitRequestByIdQuery : IRequest<VisitRequestDTO>
    {
        public int Id { get; set; }
    }
}