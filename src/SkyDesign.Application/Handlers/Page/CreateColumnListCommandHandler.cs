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
    public class CreateColumnListCommandHandler : IRequestHandler<CreateColumnListRequest, CommonResponse<CreateColumnListResponse>>
    {
        public Task<CommonResponse<CreateColumnListResponse>> Handle(CreateColumnListRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
