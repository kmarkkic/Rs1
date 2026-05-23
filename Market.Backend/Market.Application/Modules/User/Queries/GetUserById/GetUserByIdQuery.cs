using MediatR;
using Market.Application.UdomiMe_DTO;

namespace Market.Application.Modules.User.Queries.GetUserById
{
    public class GetUserByIdQuery : IRequest<UserDTO>
    {
        public int Id { get; set; }
    }
}