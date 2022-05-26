using MediatR;
using SkyDesign.Core.Base;
using System;
using System.Collections.Generic;

namespace SkyDesign.Application.Contract.Queries.Role
{
    [Serializable]
    public class GetRoleQueryRequest : IRequest<CommonResponse<List<GetRoleQueryResponse>>>
    {

    }
}
