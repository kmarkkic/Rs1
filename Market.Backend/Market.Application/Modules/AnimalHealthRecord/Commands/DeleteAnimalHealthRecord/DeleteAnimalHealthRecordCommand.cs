using MediatR;

namespace Market.Application.Modules.AnimalHealthRecord.Commands.DeleteAnimalHealthRecord
{
    public class DeleteAnimalHealthRecordCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
