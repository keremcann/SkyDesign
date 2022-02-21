using MediatR;
using SkyDesign.Application.Contract.Queries.Login;
using SkyDesign.Domain.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SkyDesign.Application.Handlers.Login
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQueryRequest, List<GetUserQueryResponse>>
    {
        IUserRepository _userRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userRepository"></param>
        public GetUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<List<GetUserQueryResponse>> Handle(GetUserQueryRequest request, CancellationToken cancellationToken)
        {
            var users = _userRepository.GetAll();

            return await Task.FromResult(new List<GetUserQueryResponse>());
        }
    }
}
