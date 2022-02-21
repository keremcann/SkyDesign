using MediatR;
using System;

namespace SkyDesign.Application.Contract.Commands.SubCatalog
{
    [Serializable]
    public class UpdateSubCatalogCommandRequest : IRequest<UpdateSubCatalogCommandResponse>
    {
        public int CatalogId { get; set; }
        public string CatalogName { get; set; }
        public string UpdateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
