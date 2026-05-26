using MediatR;

namespace Market.Application.Modules.Shelter.Commands.DeleteShelter
{
    public class DeleteShelterCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}