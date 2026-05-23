using MediatR;

namespace Market.Application.Modules.AnimalStatus.Commands.UpdateAnimalStatus
{
    public class UpdateAnimalStatusCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}