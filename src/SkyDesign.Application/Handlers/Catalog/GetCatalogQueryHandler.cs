using AutoMapper;
using MediatR;
using SkyDesign.Application.Contract.Queries.Catalog;
using SkyDesign.Core.Base;
using SkyDesign.Domain.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SkyDesign.Application.Handlers.Catalog
{
    public class GetCatalogQueryHandler : IRequestHandler<GetCatalogQueryRequest, CommonResponse<List<GetCatalogQueryResponse>>>
    {
        ICatalogRepositoryAsync _catalogRepository;
        IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="catalogRepository"></param>
        /// <param name="_mapper"></param>
        public GetCatalogQueryHandler(ICatalogRepositoryAsync catalogRepository, IMapper mapper)
        {
            _catalogRepository = catalogRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<CommonResponse<List<GetCatalogQueryResponse>>> Handle(GetCatalogQueryRequest request, CancellationToken cancellationToken)
        {
            var response = new CommonResponse<List<GetCatalogQueryResponse>>();

            var catalogs = _catalogRepository.GetAllAsync();
            if (!catalogs.Result.Success)
            {
                response.Success = catalogs.Result.Success;
                response.ErrorMessage = catalogs.Result.ErrorMessage;
                return await Task.FromResult(response);
            }
            var list = _mapper.Map<List<GetCatalogQueryResponse>>(catalogs.Result.Value);
            response.Value = list;
            response.Success = catalogs.Result.Success;
            response.ErrorMessage = catalogs.Result.InfoMessage;
            return await Task.FromResult(response);
        }
    }
}
