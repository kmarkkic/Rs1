using MediatR;
using Market.Application.UdomiMe_DTO;

namespace Market.Application.Modules.User.Queries.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<List<UserDTO>>
    {
    }
}