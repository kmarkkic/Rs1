namespace Market.Application.Modules.Animal.Commands.UpdateAnimal
{
    public record UpdateAnimalCommand(
        int Id,
        string? Name,
        string? Description,
        int Age,
        string? Gender,
        int? BreedId,
        int AnimalTypeId,
        int? ShelterId,
        int OwnerId,
        int CityId,
        int AnimalStatusId,
        bool IsVaccinated,
        bool IsSterilized
    ) : IRequest;
}