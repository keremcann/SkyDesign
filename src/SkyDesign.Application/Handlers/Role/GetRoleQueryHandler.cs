using AutoMapper;
using MediatR;
using SkyDesign.Application.Contract.Queries.Role;
using SkyDesign.Core.Base;
using SkyDesign.Domain.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SkyDesign.Application.Handlers.Role
{
    public class GetRoleQueryHandler : IRequestHandler<GetRoleQueryRequest, CommonResponse<List<GetRoleQueryResponse>>>
    {
        IRoleRepositoryAsync _roleRepository;
        IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleRepository"></param>
        /// <param name="mapper"></param>
        public GetRoleQueryHandler(IRoleRepositoryAsync roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<CommonResponse<List<GetRoleQueryResponse>>> Handle(GetRoleQueryRequest request, CancellationToken cancellationToken)
        {
            var response = new CommonResponse<List<GetRoleQueryResponse>>();

            var catalogs = _roleRepository.GetAllAsync();
            if (!catalogs.Result.Success)
            {
                response.Success = catalogs.Result.Success;
                response.ErrorMessage = catalogs.Result.ErrorMessage;
                return await Task.FromResult(response);
            }
            var list = _mapper.Map<List<GetRoleQueryResponse>>(catalogs.Result.Value);
            response.Value = list;
            response.Success = catalogs.Result.Success;
            response.ErrorMessage = catalogs.Result.InfoMessage;
            return await Task.FromResult(response);
        }
    }
}
