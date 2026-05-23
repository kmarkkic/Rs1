using MediatR;
using Market.Application.UdomiMe_DTO;

namespace Market.Application.Modules.AnimalTypes.Queries.GetAnimalTypeById
{
    public class GetAnimalTypeByIdQuery : IRequest<AnimalTypesDTO>
    {
        public int Id { get; set; }
    }
}