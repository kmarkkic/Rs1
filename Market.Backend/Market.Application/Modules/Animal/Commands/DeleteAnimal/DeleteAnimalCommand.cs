namespace Market.Application.Modules.Animal.Commands.DeleteAnimal
{
    public record DeleteAnimalCommand(int Id) : IRequest;
}