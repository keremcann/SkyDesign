using MediatR;
using SkyDesign.Core.Base;
using System;

namespace SkyDesign.Application.Contract.Commands.SubCatalog
{
    [Serializable]
    public class UpdateSubCatalogCommandRequest : IRequest<CommonResponse<UpdateSubCatalogCommandResponse>>
    {
        public int CatalogId { get; set; }
        public string CatalogName { get; set; }
        public string UpdateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
