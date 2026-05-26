using MediatR;

namespace Market.Application.Modules.AnimalTypes.Commands.CreateAnimalType
{
    public class CreateAnimalTypeCommand : IRequest<int>
    {
        public string Name { get; set; }
    }
}