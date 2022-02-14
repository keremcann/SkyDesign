using MediatR;

namespace SkyDesign.Application.Contract.Queries.Login
{
    public class GetLoginQueryRequest : IRequest<GetLoginQueryResponse>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
