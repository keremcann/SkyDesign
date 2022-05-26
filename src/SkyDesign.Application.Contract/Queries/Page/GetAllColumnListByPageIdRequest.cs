using MediatR;
using SkyDesign.Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyDesign.Application.Contract.Queries.Page
{
    public class GetAllColumnListByPageIdRequest : IRequest<CommonResponse<List<GetAllColumnListByPageIdResponse>>>
    {
        public int PageId { get; set; }
    }
}
