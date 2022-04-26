using MediatR;
using SkyDesign.Application.Contract.Commands.Page;
using SkyDesign.Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SkyDesign.Application.Handlers.Page
{
    public class UpdateColumnListCommandHandler : IRequestHandler<UpdateColumnListRequest, CommonResponse<UpdateColumnListResponse>>
    {
        public Task<CommonResponse<UpdateColumnListResponse>> Handle(UpdateColumnListRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
