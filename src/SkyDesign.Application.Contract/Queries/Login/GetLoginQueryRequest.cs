using MediatR;
using System;

namespace SkyDesign.Application.Contract.Queries.Login
{
    [Serializable]
    public class GetLoginQueryRequest : IRequest<GetLoginQueryResponse>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
