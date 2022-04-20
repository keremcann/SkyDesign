using AutoMapper;
using MediatR;
using SkyDesign.Application.Contract.Commands.Role;
using SkyDesign.Core.Base;
using SkyDesign.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SkyDesign.Application.Handlers.Role
{
    public class DeleteRoleCommandRequestHandler : IRequestHandler<DeleteRoleCommandRequest, CommonResponse<DeleteRoleCommandResponse>>
    {
        private readonly IRoleRepositoryAsync _roleRepositoryAsync;
        private readonly IMapper _mapper;

        public DeleteRoleCommandRequestHandler(IRoleRepositoryAsync roleRepositoryAsync,
                                        IMapper mapper)
        {
            _roleRepositoryAsync = roleRepositoryAsync;
            _mapper = mapper;
        }

        public async Task<CommonResponse<DeleteRoleCommandResponse>> Handle(DeleteRoleCommandRequest request, CancellationToken cancellationToken)
        {
            var roleToDelete = _mapper.Map<Domain.Entities.Role>(request);

            var result = await _roleRepositoryAsync.DeleteAsync(roleToDelete);

            return new CommonResponse<DeleteRoleCommandResponse>
            {
                Success = result.Success,
                InfoMessage = result.InfoMessage,
                ErrorMessage = result.ErrorMessage
            };
        }
    }
}
