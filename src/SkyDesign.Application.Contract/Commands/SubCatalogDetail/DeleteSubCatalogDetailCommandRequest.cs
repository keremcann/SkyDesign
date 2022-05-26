using MediatR;
using SkyDesign.Core.Base;
using System;

namespace SkyDesign.Application.Contract.Commands.SubCatalogDetail
{
    [Serializable]
    public class DeleteSubCatalogDetailCommandRequest : IRequest<CommonResponse<DeleteSubCatalogDetailCommandResponse>>
    {
        public int SubCatalogDetailId { get; set; }
    }
}
