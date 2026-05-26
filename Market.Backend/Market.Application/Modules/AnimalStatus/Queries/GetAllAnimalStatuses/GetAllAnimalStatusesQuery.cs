using MediatR;
using Market.Application.UdomiMe_DTO;

namespace Market.Application.Modules.AnimalStatus.Queries.GetAllAnimalStatuses
{
    public class GetAllAnimalStatusesQuery : IRequest<List<AnimalStatusDTO>>
    {
    }
}