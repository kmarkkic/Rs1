using MediatR;

namespace Market.Application.Modules.AnimalStatus.Commands.CreateAnimalStatus
{
    public class CreateAnimalStatusCommand : IRequest<int>
    {
        public string Name { get; set; }
    }
}