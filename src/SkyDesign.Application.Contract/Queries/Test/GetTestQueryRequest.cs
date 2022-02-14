using MediatR;
using System.Collections.Generic;

namespace SkyDesign.Application.Contract.Queries.Test
{
    public class GetTestQueryRequest : IRequest<List<GetTestQueryResponse>>
    {
        public int Id { get; set; }
        public string Value { get; set; }
    }
}
