using MediatR;
using Market.Application.UdomiMe_DTO;

namespace Market.Application.Modules.Shelter.Queries.GetShelterById
{
    public class GetShelterByIdQuery : IRequest<ShelterDTO>
    {
        public int Id { get; set; }
    }
}