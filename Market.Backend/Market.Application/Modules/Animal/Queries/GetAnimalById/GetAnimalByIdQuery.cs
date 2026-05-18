using Market.Application.UdomiMe_DTO;

namespace Market.Application.Modules.Animal.Queries.GetAnimalById
{
    public record GetAnimalByIdQuery(int Id) : IRequest<AnimalDTO>;
}