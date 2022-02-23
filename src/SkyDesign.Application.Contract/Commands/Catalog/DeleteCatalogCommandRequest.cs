using MediatR;
using System;

namespace SkyDesign.Application.Contract.Commands.Catalog
{
    [Serializable]
    public class DeleteCatalogCommandRequest : IRequest<DeleteCatalogCommandResponse>
    {
        public int CatalogId { get; set; }
        public string DeleteUser { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
