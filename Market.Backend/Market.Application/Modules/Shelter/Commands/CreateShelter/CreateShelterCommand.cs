using MediatR;

namespace Market.Application.Modules.Shelter.Commands.CreateShelter
{
    public class CreateShelterCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int CityId { get; set; }
    }
}