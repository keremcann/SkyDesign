using MediatR;
using SkyDesign.Core.Base;
using System;
using System.Collections.Generic;

namespace SkyDesign.Application.Contract.Queries.SubCatalog
{
    [Serializable]
    public class GetSubCatalogQueryRequest : IRequest<CommonResponse<List<GetSubCatalogQueryResponse>>>
    {
    }
}
