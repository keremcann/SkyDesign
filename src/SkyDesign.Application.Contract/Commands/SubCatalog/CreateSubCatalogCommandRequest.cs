using MediatR;
using SkyDesign.Core.Base;
using System;

namespace SkyDesign.Application.Contract.Commands.SubCatalog
{
    [Serializable]
    public class CreateSubCatalogCommandRequest : IRequest<CommonResponse<CreateSubCatalogCommandResponse>>
    {
        public string CatalogName { get; set; }
        public string CreateUser { get; set; }
    }
}
