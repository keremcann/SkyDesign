using MediatR;
using SkyDesign.Core.Base;
using System;
using System.Collections.Generic;

namespace SkyDesign.Application.Contract.Queries.SubCatalogDetail
{
    [Serializable]
    public class GetSubCatalogDetailBySubCatalogIdQueryRequest : IRequest<CommonResponse<List<GetSubCatalogDetailBySubCatalogIdQueryResponse>>>
    {
        public int SubCatalogId { get; set; }
    }
}