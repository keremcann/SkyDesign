using MediatR;
using System;
using System.Collections.Generic;

namespace SkyDesign.Application.Contract.Queries.Login
{
    [Serializable]
    public class GetUserQueryRequest : IRequest<List<GetUserQueryResponse>>
    {
        public string Email { get; set; }
        public string Password { get; set; }        
    }
}
