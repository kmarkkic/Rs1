using MediatR;

namespace Market.Application.Modules.AnimalStatus.Commands.DeleteAnimalStatus
{
    public class DeleteAnimalStatusCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}