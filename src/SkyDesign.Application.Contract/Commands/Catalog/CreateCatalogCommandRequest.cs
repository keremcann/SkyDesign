using MediatR;
using System;

namespace SkyDesign.Application.Contract.Commands.Catalog
{
    [Serializable]
    public class CreateCatalogCommandRequest : IRequest<CreateCatalogCommandResponse>
    {
        public string CatalogName { get; set; }
        public string CreateUser { get; set; }
    }
}
