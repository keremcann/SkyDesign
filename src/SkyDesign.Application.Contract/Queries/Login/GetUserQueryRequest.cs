using MediatR;
using System;
using System.Collections.Generic;

namespace SkyDesign.Application.Contract.Queries.Login
{
    [Serializable]
    public class GetUserQueryRequest : IRequest<List<GetUserQueryResponse>>
    {

    }
}
