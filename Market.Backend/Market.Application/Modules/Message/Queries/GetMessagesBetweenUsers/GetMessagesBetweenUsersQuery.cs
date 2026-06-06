using MediatR;
using Market.Application.UdomiMe_DTO;

namespace Market.Application.Modules.Message.Queries.GetMessagesBetweenUsers
{
    public class GetMessagesBetweenUsersQuery : IRequest<List<MessageDTO>>
    {
        public int UserId1 { get; set; }
        public int UserId2 { get; set; }
    }
}
