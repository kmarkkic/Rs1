using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Market.Application.Modules.Breeds.Commands.DeleteBreed
{
    public class DeleteBreedCommandHandler : IRequestHandler<DeleteBreedCommand>
    {
        private readonly IAppDbContext _context;
        public DeleteBreedCommandHandler(IAppDbContext context)
        {
            _context = context;
        }
        public async Task Handle(DeleteBreedCommand request, CancellationToken cancellationToken)
        {
            var breed = await _context.Breeds
                .FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted, cancellationToken);
            if (breed == null)
            {
                               throw new Exception("Breed is deleted");
            }
            breed.IsDeleted = true;
            await _context.SaveChangesAsync(cancellationToken); 
           
        }
    }
}
