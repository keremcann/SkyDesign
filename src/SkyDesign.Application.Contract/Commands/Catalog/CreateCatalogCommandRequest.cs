using MediatR;

namespace SkyDesign.Application.Contract.Commands.Catalog
{
    public class CreateCatalogCommandRequest : IRequest<CreateCatalogCommandResponse>
    {
        public string CatalogName { get; set; }
        public string CreateUser { get; set; }
    }
}
