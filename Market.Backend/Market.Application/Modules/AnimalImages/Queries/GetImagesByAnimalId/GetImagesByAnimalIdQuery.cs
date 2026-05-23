using MediatR;
using Market.Application.UdomiMe_DTO;

namespace Market.Application.Modules.AnimalImages.Queries.GetImagesByAnimalId
{
    public class GetImagesByAnimalIdQuery : IRequest<List<AnimalImagesDTO>>
    {
        public int AnimalId { get; set; }
    }
}