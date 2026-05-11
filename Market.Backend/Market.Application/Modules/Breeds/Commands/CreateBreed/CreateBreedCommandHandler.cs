using Market.Application.UdomiMe_DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Modules.Breeds.Commands.CreateBreed
{
    public class CreateBreedCommandHandler : IRequestHandler<CreateBreedCommand, BreedsDTO>
    {

        IAppDbContext _context;
        public CreateBreedCommandHandler(IAppDbContext context)
        {
            _context = context;
        }


        public async Task<BreedsDTO> Handle(CreateBreedCommand request, CancellationToken cancellationToken)
        {
            var result = new Breed
            {
                Name = request.Name,
                AnimalTypeId = request.AnimalTypeId
            };
            _context.Breeds.Add(result);
            await _context.SaveChangesAsync(cancellationToken);

            return new BreedsDTO
            {
                Id = result.Id,
                Name = result.Name,
                AnimalTypeId = result.AnimalTypeId
            }
            ;
        }
    }
}
