using MediatR;
using Market.Application.UdomiMe_DTO;

namespace Market.Application.Modules.Shelter.Queries.GetAllShelters
{
    public class GetAllSheltersQuery : IRequest<List<ShelterDTO>>
    {
    }
}