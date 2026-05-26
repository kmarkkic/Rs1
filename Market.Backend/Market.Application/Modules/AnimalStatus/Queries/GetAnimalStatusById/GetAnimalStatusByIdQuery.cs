using MediatR;
using Market.Application.UdomiMe_DTO;

namespace Market.Application.Modules.AnimalStatus.Queries.GetAnimalStatusById
{
    public class GetAnimalStatusByIdQuery : IRequest<AnimalStatusDTO>
    {
        public int Id { get; set; }
    }
}