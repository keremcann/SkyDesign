using MediatR;
using System;

namespace SkyDesign.Application.Contract.Commands.Catalog
{
    [Serializable]
    public class UpdateCatalogCommandRequest : IRequest<UpdateCatalogCommandResponse>
    {
        public int CatalogId { get; set; }
        public string CatalogName { get; set; }
        public string UpdateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
