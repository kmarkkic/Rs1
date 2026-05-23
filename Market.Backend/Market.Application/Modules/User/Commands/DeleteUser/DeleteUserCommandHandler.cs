using MediatR;
using Market.Application.Abstractions;

namespace Market.Application.Modules.User.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Unit>
    {
        private readonly IAppDbContext _context;

        public DeleteUserCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FindAsync(request.Id);

            if (user == null)
                throw new Exception($"User with ID {request.Id} not found.");

            _context.Users.Remove(user);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}