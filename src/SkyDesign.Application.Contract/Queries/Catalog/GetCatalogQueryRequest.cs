using MediatR;
using System;
using System.Collections.Generic;

namespace SkyDesign.Application.Contract.Queries.Catalog
{
    [Serializable]
    public class GetCatalogQueryRequest : IRequest<List<GetCatalogQueryResponse>>
    {
    }
}
