using MediatR;
using SkyDesign.Application.Contract.Queries.Login;
using SkyDesign.Core.Auth;
using SkyDesign.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace SkyDesign.Application.Handlers.Login
{
    public class GetLoginQueryHandler : IRequestHandler<GetLoginQueryRequest, GetLoginQueryResponse>
    {
        IAuthentication _authentication;
        IUserRepositoryAsync _userRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="authentication"></param>
        public GetLoginQueryHandler(IAuthentication authentication, IUserRepositoryAsync userRepository)
        {
            _authentication = authentication;
            _userRepository = userRepository;
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

            var user = _userRepository.GetItemAsync(new Domain.Entities.User { UserName = request.UserName, Password = request.Password });

            if (!user.Result.Success)
                return new GetLoginQueryResponse { Success = user.Result.Success, ErrorMessage = user.Result.ErrorMessage };

            if (user == null)
                return new GetLoginQueryResponse { Success = false, ErrorMessage = "Kullanıcı bulunamadı!" };

            var result = await _authentication.Authenticate(request.UserName, request.Password, "Admin");
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
            response.FullName = user.Result.Value.FullName;
            return await Task.FromResult(response);
        }
    }
}
