using MediatR;
using Market.Application.UdomiMe_DTO;

namespace Market.Application.Modules.AnimalHealthRecord.Queries.GetHealthRecordById
{
    public class GetHealthRecordByIdQuery : IRequest<AnimalHealthRecordDTO>
    {
        public int Id { get; set; }
    }
}
