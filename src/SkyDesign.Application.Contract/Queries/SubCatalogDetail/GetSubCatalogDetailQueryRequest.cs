using MediatR;
using System;
using System.Collections.Generic;

namespace SkyDesign.Application.Contract.Queries.SubCatalogDetail
{
    [Serializable]
    public class GetSubCatalogDetailQueryRequest : IRequest<List<GetSubCatalogDetailQueryResponse>>
    {
    }
}
