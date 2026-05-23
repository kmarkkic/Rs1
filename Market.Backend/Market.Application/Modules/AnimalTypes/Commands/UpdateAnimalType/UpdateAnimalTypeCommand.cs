using MediatR;

namespace Market.Application.Modules.AnimalTypes.Commands.UpdateAnimalType
{
    public class UpdateAnimalTypeCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}