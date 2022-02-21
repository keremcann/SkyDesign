using MediatR;
using System;

namespace SkyDesign.Application.Contract.Commands.SubCatalogDetail
{
    [Serializable]
    public class DeleteSubCatalogDetailCommandRequest : IRequest<DeleteSubCatalogDetailCommandResponse>
    {
    }
}
