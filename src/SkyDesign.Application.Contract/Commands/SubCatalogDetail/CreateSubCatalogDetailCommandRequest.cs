using MediatR;
using SkyDesign.Core.Base;
using System;

namespace SkyDesign.Application.Contract.Commands.SubCatalogDetail
{
    [Serializable]
    public class CreateSubCatalogDetailCommandRequest : IRequest<CommonResponse<CreateSubCatalogDetailCommandResponse>>
    {
        public string CatalogName { get; set; }
        public string CreateUser { get; set; }
    }
}
