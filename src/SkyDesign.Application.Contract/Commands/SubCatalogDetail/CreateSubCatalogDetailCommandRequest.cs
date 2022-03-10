using MediatR;
using SkyDesign.Core.Base;
using System;

namespace SkyDesign.Application.Contract.Commands.SubCatalogDetail
{
    [Serializable]
    public class CreateSubCatalogDetailCommandRequest : IRequest<CommonResponse<CreateSubCatalogDetailCommandResponse>>
    {
        public int SubCatalogId { get; set; }
        public string CatalogName { get; set; }
        public string CreateUser { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
