using Market.Application.UdomiMe_DTO;

namespace Market.Application.Modules.Animal.Queries.GetAnimals
{
    public record GetAnimalsQuery : IRequest<List<AnimalDTO>>;
}