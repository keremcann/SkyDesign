using MediatR;
using System;
using System.Collections.Generic;

namespace SkyDesign.Application.Contract.Queries.SubCatalog
{
    [Serializable]
    public class GetSubCatalogQueryRequest : IRequest<List<GetSubCatalogQueryResponse>>
    {
    }
}
