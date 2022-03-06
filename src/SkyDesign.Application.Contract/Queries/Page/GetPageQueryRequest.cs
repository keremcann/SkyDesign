using MediatR;
using SkyDesign.Core.Base;
using System;
using System.Collections.Generic;

namespace SkyDesign.Application.Contract.Queries.Page
{
    [Serializable]
    public class GetPageQueryRequest : IRequest<CommonResponse<List<GetPageQueryResponse>>>
    {
        public int PageId { get; set; }
        public int RoleId { get; set; }
    }
}
