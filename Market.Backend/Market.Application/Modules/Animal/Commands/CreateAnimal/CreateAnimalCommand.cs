using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Modules.Animal.Commands.CreateAnimal
{
    public record CreateAnimalCommand(
      string? Name,
      string? Description,
      int Age,
      string? Gender,
      int BreedId,
      int AnimalTypeId,
      int ShelterId,
      int OwnerId,     
      int CityId,      
      int AnimalStatusId,
      bool IsVaccinated,
      bool IsSterilized
  ) : IRequest<int>;
}
