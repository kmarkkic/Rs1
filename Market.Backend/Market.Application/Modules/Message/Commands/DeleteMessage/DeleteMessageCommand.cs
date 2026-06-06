using MediatR;

namespace Market.Application.Modules.Message.Commands.DeleteMessage
{
    public class DeleteMessageCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
