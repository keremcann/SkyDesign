using MediatR;
using System;

namespace SkyDesign.Application.Contract.Commands.SubCatalogDetail
{
    [Serializable]
    public class CreateSubCatalogDetailCommandRequest : IRequest<CreateSubCatalogDetailCommandResponse>
    {
        public string CatalogName { get; set; }
        public string CreateUser { get; set; }
    }
}
