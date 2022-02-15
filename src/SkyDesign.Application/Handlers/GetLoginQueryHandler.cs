using MediatR;
using SkyDesign.Application.Contract.Queries.Login;
using SkyDesign.Core.Auth;
using System.Threading;
using System.Threading.Tasks;

namespace SkyDesign.Application.Handlers
{
    public class GetLoginQueryHandler : IRequestHandler<GetLoginQueryRequest, GetLoginQueryResponse>
    {
        IAuthentication _authentication;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="authentication"></param>
        public GetLoginQueryHandler(IAuthentication authentication)
        {
            _authentication = authentication;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<GetLoginQueryResponse> Handle(GetLoginQueryRequest request, CancellationToken cancellationToken)
        {
            var response = new GetLoginQueryResponse();
            var result = await _authentication.Authenticate(request.UserName, request.Password);
            if (!result.Success)
            {
                response.Success = result.Success;
                response.ErrorMessage = result.Value;
                response.Token = string.Empty;
                return await Task.FromResult(response);
            }
            response.Success = result.Success;
            response.InfoMessage = "";
            response.Token = result.Value;
            return await Task.FromResult(response);
        }
    }
}
