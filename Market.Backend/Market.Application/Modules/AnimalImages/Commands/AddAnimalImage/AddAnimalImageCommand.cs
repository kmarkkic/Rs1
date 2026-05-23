using MediatR;

namespace Market.Application.Modules.AnimalImages.Commands.AddAnimalImage
{
    public class AddAnimalImageCommand : IRequest<int>
    {
        public int AnimalId { get; set; }
        public string ImageUrl { get; set; }
    }
}