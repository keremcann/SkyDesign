using MediatR;
using System;

namespace SkyDesign.Application.Contract.Commands.SubCatalogDetail
{
    [Serializable]
    public class UpdateSubCatalogDetailCommandRequest : IRequest<UpdateSubCatalogDetailCommandResponse>
    {
        public int CatalogId { get; set; }
        public string CatalogName { get; set; }
        public string UpdateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
