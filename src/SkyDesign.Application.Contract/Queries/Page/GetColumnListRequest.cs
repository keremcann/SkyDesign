using MediatR;
using SkyDesign.Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyDesign.Application.Contract.Queries.Page
{
    public class GetColumnListRequest : IRequest<CommonResponse<List<GetColumnListResponse>>>
    {

    }
}