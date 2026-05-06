using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Modules.Cities.Commands.DeleteCity
{
    public class DeleteCityCommandHandler : IRequestHandler<DeleteCityCommand>
    {
        private readonly IAppDbContext _context;

        public DeleteCityCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task Handle(DeleteCityCommand request, CancellationToken cancellationToken)
        {
            var city = await _context.Cities
                .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (city == null)
                throw new Exception("Grad nije pronađen");

            city.IsDeleted = true;
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}