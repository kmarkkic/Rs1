using MediatR;

namespace Market.Application.Modules.Message.Commands.MarkMessageAsRead
{
    public class MarkMessageAsReadCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
