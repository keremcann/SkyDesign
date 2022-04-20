using AutoMapper;
using MediatR;
using SkyDesign.Application.Contract.Commands.Role;
using SkyDesign.Core.Base;
using SkyDesign.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace SkyDesign.Application.Handlers.Role
{
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommandRequest, CommonResponse<CreateRoleCommandResponse>>
    {
        private readonly IRoleRepositoryAsync _roleRepositoryAsync;
        private readonly IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleRepositoryAsync"></param>
        /// <param name="mapper"></param>
        public CreateRoleCommandHandler(IRoleRepositoryAsync roleRepositoryAsync, IMapper mapper)
        {
            _roleRepositoryAsync = roleRepositoryAsync;
            _mapper = mapper;
        }

        public async Task<CommonResponse<CreateRoleCommandResponse>> Handle(CreateRoleCommandRequest request, CancellationToken cancellationToken)
        {
            var roleToAdd = _mapper.Map<Domain.Entities.Role>(request);

            var result = await _roleRepositoryAsync.AddAsync(roleToAdd);

            return new CommonResponse<CreateRoleCommandResponse>
            {
                Success = result.Success,
                InfoMessage = result.InfoMessage,
                ErrorMessage = result.ErrorMessage
            };
        }
    }
}