using AutoMapper;
using MediatR;
using SkyDesign.Application.Contract.Commands.Role;
using SkyDesign.Core.Base;
using SkyDesign.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace SkyDesign.Application.Handlers.Role
{
    public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommandRequest, CommonResponse<UpdateRoleCommandResponse>>
    {
        private readonly IRoleRepositoryAsync _roleRepositoryAsync;
        private readonly IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleRepositoryAsync"></param>
        /// <param name="mapper"></param>
        public UpdateRoleCommandHandler(IRoleRepositoryAsync roleRepositoryAsync, IMapper mapper)
        {
            _roleRepositoryAsync = roleRepositoryAsync;
            _mapper = mapper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<CommonResponse<UpdateRoleCommandResponse>> Handle(UpdateRoleCommandRequest request, CancellationToken cancellationToken)
        {
            var roleToAdd = _mapper.Map<Domain.Entities.Role>(request);

            var result = await _roleRepositoryAsync.UpdateAsync(roleToAdd);

            return new CommonResponse<UpdateRoleCommandResponse>
            {
                Success = result.Success,
                InfoMessage = result.InfoMessage,
                ErrorMessage = result.ErrorMessage
            };
        }
    }
}
