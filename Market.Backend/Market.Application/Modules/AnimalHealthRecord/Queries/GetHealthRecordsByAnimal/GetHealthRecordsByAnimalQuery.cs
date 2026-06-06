using MediatR;
using Market.Application.UdomiMe_DTO;

namespace Market.Application.Modules.AnimalHealthRecord.Queries.GetHealthRecordsByAnimal
{
    public class GetHealthRecordsByAnimalQuery : IRequest<List<AnimalHealthRecordDTO>>
    {
        public int AnimalId { get; set; }
    }
}
