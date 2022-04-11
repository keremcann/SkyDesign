using MediatR;
using SkyDesign.Core.Base;
using System;
using System.Collections.Generic;

namespace SkyDesign.Application.Contract.Queries.Diagram
{
    [Serializable]
    public class GetDiagramQueryRequest : IRequest<CommonResponse<List<GetDiagramQueryResponse>>>
    {
        public int DiagramId { get; set; }
        public int PageId { get; set; }
    }
}
