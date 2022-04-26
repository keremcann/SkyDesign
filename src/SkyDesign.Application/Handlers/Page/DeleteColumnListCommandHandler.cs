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
    public class DeleteColumnListCommandHandler : IRequestHandler<DeleteColumnListRequest, CommonResponse<DeleteColumnListResponse>>
    {
        public Task<CommonResponse<DeleteColumnListResponse>> Handle(DeleteColumnListRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}