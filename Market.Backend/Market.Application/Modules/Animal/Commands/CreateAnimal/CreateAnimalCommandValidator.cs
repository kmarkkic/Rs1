namespace Market.Application.Modules.Animal.Commands.CreateAnimal
{
    public sealed class CreateAnimalCommandValidator : AbstractValidator<CreateAnimalCommand>
    {
        public CreateAnimalCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MinimumLength(2).WithMessage("Name must be at least 2 characters long.")
                .MaximumLength(100).WithMessage("Name can be up to 100 characters long.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(1000).WithMessage("Description can be up to 1000 characters long.");

            RuleFor(x => x.Age)
                .NotEmpty().WithMessage("Age is required.")
                .GreaterThan(0).WithMessage("Age must be a positive number.")
                .LessThanOrEqualTo(30).WithMessage("Age must not exceed 30.");

            RuleFor(x => x.Gender)
                .NotEmpty().WithMessage("Gender is required.")
                .MaximumLength(20).WithMessage("Gender can be up to 20 characters long.");

            RuleFor(x => x.AnimalTypeId)
                .GreaterThan(0).WithMessage("AnimalTypeId is required and must be a valid id.");

            RuleFor(x => x.AnimalStatusId)
                .GreaterThan(0).WithMessage("AnimalStatusId is required and must be a valid id.");

            RuleFor(x => x.ShelterId)
                .GreaterThan(0).WithMessage("ShelterId is required and must be a valid id.");

            RuleFor(x => x.BreedId)
                .GreaterThan(0).WithMessage("BreedId must be a valid id.");

            RuleFor(x => x.OwnerId)
                .GreaterThan(0).WithMessage("OwnerId is required and must be a valid id.");

            RuleFor(x => x.CityId)
                .GreaterThan(0).WithMessage("CityId is required and must be a valid id.");
        }
    }
}
