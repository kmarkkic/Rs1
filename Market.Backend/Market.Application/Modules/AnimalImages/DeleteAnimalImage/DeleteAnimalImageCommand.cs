using MediatR;

namespace Market.Application.Modules.AnimalImages.Commands.DeleteAnimalImage
{
    public class DeleteAnimalImageCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}