using MediatR;
using SkyDesign.Core.Base;
using System;

namespace SkyDesign.Application.Contract.Commands.Catalog
{
    [Serializable]
    public class CreateCatalogCommandRequest : IRequest<CommonResponse<CreateCatalogCommandResponse>>
    {
        public string CatalogName { get; set; }
        public string CreateUser { get; set; }
    }
}
