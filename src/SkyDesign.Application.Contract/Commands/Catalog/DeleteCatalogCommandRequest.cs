using MediatR;
using System;

namespace SkyDesign.Application.Contract.Commands.Catalog
{
    [Serializable]
    public class DeleteCatalogCommandRequest : IRequest<DeleteCatalogCommandResponse>
    {
    }
}
