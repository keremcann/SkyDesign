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
        IUserRepository _userRepository;
        IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userRepository"></param>
        /// <param name="mapper"></param>
        public GetUserQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
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
            var list = _mapper.Map<List<GetUserQueryResponse>>(users.Value);
            return await Task.FromResult(list);
        }
    }
}
