using MediatR;

namespace Market.Application.Modules.AnimalHealthRecord.Commands.CreateAnimalHealthRecord
{
    public class CreateAnimalHealthRecordCommand : IRequest<int>
    {
        public int AnimalId { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string VetName { get; set; }
    }
}
