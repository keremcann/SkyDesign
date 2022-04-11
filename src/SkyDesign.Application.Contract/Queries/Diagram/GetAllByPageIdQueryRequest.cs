using MediatR;
using SkyDesign.Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyDesign.Application.Contract.Queries.Diagram
{
    public class GetAllByPageIdQueryRequest : IRequest<CommonResponse<List<GetAllByPageIdQueryResponse>>>
    {
        public int PageId { get; set; }
    }
}
