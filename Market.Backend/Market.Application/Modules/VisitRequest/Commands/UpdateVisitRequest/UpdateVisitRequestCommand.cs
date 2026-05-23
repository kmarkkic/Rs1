using MediatR;

namespace Market.Application.Modules.VisitRequest.Commands.UpdateVisitRequest
{
    public class UpdateVisitRequestCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int AnimalId { get; set; }
        public DateTime VisitDate { get; set; }
        public string Note { get; set; }
    }
}