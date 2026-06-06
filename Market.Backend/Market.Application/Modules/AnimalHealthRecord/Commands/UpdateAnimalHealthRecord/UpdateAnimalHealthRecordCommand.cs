using MediatR;

namespace Market.Application.Modules.AnimalHealthRecord.Commands.UpdateAnimalHealthRecord
{
    public class UpdateAnimalHealthRecordCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string VetName { get; set; }
    }
}
