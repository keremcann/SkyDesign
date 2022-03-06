using AutoMapper;
using MediatR;
using SkyDesign.Application.Contract.Queries.Page;
using SkyDesign.Core.Base;
using SkyDesign.Domain.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SkyDesign.Application.Handlers.Page
{
    public class GetPageQueryHandler : IRequestHandler<GetPageQueryRequest, CommonResponse<List<GetPageQueryResponse>>>
    {
        IPageRepositoryAsync _pageRepository;
        IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleRepository"></param>
        /// <param name="mapper"></param>
        public GetPageQueryHandler(IPageRepositoryAsync roleRepository, IMapper mapper)
        {
            _pageRepository = roleRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<CommonResponse<List<GetPageQueryResponse>>> Handle(GetPageQueryRequest request, CancellationToken cancellationToken)
        {
            var response = new CommonResponse<List<GetPageQueryResponse>>();

            var catalogs = _pageRepository.GetAllAsync();
            if (!catalogs.Result.Success)
            {
                response.Success = catalogs.Result.Success;
                response.ErrorMessage = catalogs.Result.ErrorMessage;
                return await Task.FromResult(response);
            }
            var list = _mapper.Map<List<GetPageQueryResponse>>(catalogs.Result.Value);
            response.Value = list;
            response.Success = catalogs.Result.Success;
            response.ErrorMessage = catalogs.Result.InfoMessage;
            return await Task.FromResult(response);
        }
    }
}
