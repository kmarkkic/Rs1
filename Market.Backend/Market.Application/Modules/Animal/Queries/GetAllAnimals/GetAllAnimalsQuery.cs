using Market.Application.UdomiMe_DTO;

namespace Market.Application.Modules.Animal.Queries.GetAnimals
{
    public record GetAnimalsQuery(int? AnimalTypeId, int? BreedId, int? Age, string? Gender, string? Name, int? AnimalStatusId, PageRequest Paging) : IRequest<PageResult<AnimalDTO>>;
}