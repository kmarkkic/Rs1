using MediatR;

namespace Market.Application.Modules.AnimalTypes.Commands.DeleteAnimalType
{
    public class DeleteAnimalTypeCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}