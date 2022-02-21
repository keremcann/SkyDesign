using MediatR;
using System;

namespace SkyDesign.Application.Contract.Commands.SubCatalog
{
    [Serializable]
    public class CreateSubCatalogCommandRequest : IRequest<CreateSubCatalogCommandResponse>
    {
        public string CatalogName { get; set; }
        public string CreateUser { get; set; }
    }
}
