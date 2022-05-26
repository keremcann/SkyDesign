using MediatR;
using SkyDesign.Core.Base;
using System;

namespace SkyDesign.Application.Contract.Commands.SubCatalogDetail
{
    [Serializable]
    public class UpdateSubCatalogDetailCommandRequest : IRequest<CommonResponse<UpdateSubCatalogDetailCommandResponse>>
    {
        public int SubCatalogDetailId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }
}
