using MediatR;
using SkyDesign.Core.Base;
using System;
using System.Collections.Generic;

namespace SkyDesign.Application.Contract.Queries.Catalog
{
    [Serializable]
    public class GetCatalogQueryRequest : IRequest<CommonResponse<List<GetCatalogQueryResponse>>>
    {
    }
}
