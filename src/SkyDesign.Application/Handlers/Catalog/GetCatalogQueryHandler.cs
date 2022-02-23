using AutoMapper;
using MediatR;
using SkyDesign.Application.Contract.Queries.Catalog;
using SkyDesign.Core.Base;
using SkyDesign.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SkyDesign.Application.Handlers.Catalog
{
    public class GetCatalogQueryHandler : IRequestHandler<GetCatalogQueryRequest, List<GetCatalogQueryResponse>>
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
        public async Task<List<GetCatalogQueryResponse>> Handle(GetCatalogQueryRequest request, CancellationToken cancellationToken)
        {
            var response = new CommonResponse<List<GetCatalogQueryResponse>>();
           
            var catalogs = _catalogRepository.GetAllAsync();
            var list = _mapper.Map<List<GetCatalogQueryResponse>>(catalogs.Result.Value);
            return await Task.FromResult(list);
        }
    }
}
