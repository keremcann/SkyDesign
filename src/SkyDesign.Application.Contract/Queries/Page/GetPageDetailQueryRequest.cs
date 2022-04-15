using MediatR;
using SkyDesign.Core.Base;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SkyDesign.Application.Contract.Queries.Page
{
    [Serializable]
    public class GetPageDetailQueryRequest : IRequest<CommonResponse<GetPageDetailQueryResponse>>
    {
        public string Level1Menu { get; set; }
        public string Level2Menu { get; set; }
        public string Level3Menu { get; set; }
    }

    public class GetPageDetailQueryResponse
    {
        public object Result { get; set; }
    }
}