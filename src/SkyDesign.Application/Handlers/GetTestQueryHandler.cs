using MediatR;
using SkyDesign.Application.Contract.Queries.Test;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SkyDesign.Application.Handlers
{
    public class GetTestQueryHandler : IRequestHandler<GetTestQueryRequest, List<GetTestQueryResponse>>
    {
        public GetTestQueryHandler()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<List<GetTestQueryResponse>> Handle(GetTestQueryRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
