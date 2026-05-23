using MediatR;

namespace Market.Application.Modules.VisitRequest.Commands.CreateVisitRequest
{
    public class CreateVisitRequestCommand : IRequest<int>
    {
        public int UserId { get; set; }
        public int AnimalId { get; set; }
        public DateTime VisitDate { get; set; }
        public string Note { get; set; }
    }
}