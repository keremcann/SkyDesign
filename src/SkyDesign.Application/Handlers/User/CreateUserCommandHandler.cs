using AutoMapper;
using MediatR;
using SkyDesign.Application.Contract.Commands.User;
using SkyDesign.Core.Base;
using SkyDesign.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace SkyDesign.Application.Handlers.User
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CommonResponse<CreateUserCommandResponse>>
    {
        private readonly IUserRepositoryAsync _userRepositoryAsync;
        private readonly IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userRepositoryAsync"></param>
        /// <param name="mapper"></param>
        public CreateUserCommandHandler(IUserRepositoryAsync userRepositoryAsync, IMapper mapper)
        {
            _userRepositoryAsync = userRepositoryAsync;
            _mapper = mapper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<CommonResponse<CreateUserCommandResponse>> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            var userMapper = _mapper.Map<Domain.Entities.User>(request);

            var result = await _userRepositoryAsync.AddAsync(userMapper);

            return new CommonResponse<CreateUserCommandResponse>
            {
                Success = result.Success,
                InfoMessage = result.InfoMessage,
                ErrorMessage = result.ErrorMessage
            };
        }
    }
}
