using MediatR;
using Market.Application.UdomiMe_DTO;

namespace Market.Application.Modules.AnimalTypes.Queries.GetAllAnimalTypes
{
    public class GetAllAnimalTypesQuery : IRequest<List<AnimalTypesDTO>>
    {
    }
}