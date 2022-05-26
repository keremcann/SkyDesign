using MediatR;
using SkyDesign.Core.Base;
using System;

namespace SkyDesign.Application.Contract.Commands.SubCatalog
{
    [Serializable]
    public class DeleteSubCatalogCommandRequest : IRequest<CommonResponse<DeleteSubCatalogCommandResponse>>
    {
    }
}
