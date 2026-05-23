using MediatR;
using Market.Application.Abstractions;
using Market.Application.UdomiMe_DTO;
using Microsoft.EntityFrameworkCore;

namespace Market.Application.Modules.User.Queries.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDTO>
    {
        private readonly IAppDbContext _context;

        public GetUserByIdQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<UserDTO> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users
                .Where(u => u.Id == request.Id)
                .Select(u => new UserDTO
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email,
                    PhoneNumber = u.PhoneNumber,
                    CityId = u.CityId
                })
                .FirstOrDefaultAsync(cancellationToken);

            if (user == null)
                throw new Exception($"User with ID {request.Id} not found.");

            return user;
        }
    }
}