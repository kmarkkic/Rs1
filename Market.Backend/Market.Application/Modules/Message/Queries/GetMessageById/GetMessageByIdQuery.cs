using MediatR;
using Market.Application.UdomiMe_DTO;

namespace Market.Application.Modules.Message.Queries.GetMessageById
{
    public class GetMessageByIdQuery : IRequest<MessageDTO>
    {
        public int Id { get; set; }
    }
}
