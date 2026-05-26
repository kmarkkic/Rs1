using MediatR;

namespace Market.Application.Modules.VisitRequest.Commands.DeleteVisitRequest
{
    public class DeleteVisitRequestCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}