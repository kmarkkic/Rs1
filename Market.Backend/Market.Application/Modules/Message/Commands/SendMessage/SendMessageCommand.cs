using MediatR;

namespace Market.Application.Modules.Message.Commands.SendMessage
{
    public class SendMessageCommand : IRequest<int>
    {
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public string Content { get; set; }
    }
}
