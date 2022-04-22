using AutoMapper;
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
        private readonly IUserRepositoryAsync _userRepositoryAsync;
        private readonly IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userRepository"></param>
        /// <param name="mapper"></param>
        public GetUserQueryHandler(IMapper mapper, IUserRepositoryAsync userRepositoryAsync)
        {
            _mapper = mapper;
            _userRepositoryAsync = userRepositoryAsync;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<List<GetUserQueryResponse>> Handle(GetUserQueryRequest request, CancellationToken cancellationToken)
        {
            var users = await _userRepositoryAsync.GetAllAsync();
            var list = _mapper.Map<List<GetUserQueryResponse>>(users.Value);
            return await Task.FromResult(list);
        }
    }
}
