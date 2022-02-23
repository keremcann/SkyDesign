using AutoMapper;
using MediatR;
using SkyDesign.Application.Contract.Queries.SubCatalog;
using SkyDesign.Core.Base;
using SkyDesign.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SkyDesign.Application.Handlers.SubCatalog
{
    public class GetSubCatalogQueryHandler : IRequestHandler<GetSubCatalogQueryRequest, List<GetSubCatalogQueryResponse>>
    {
        ISubCatalogRepositoryAsync _subCatalogRepository;
        IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_subCatalogRepository"></param>
        /// <param name="_mapper"></param>
        public GetSubCatalogQueryHandler(ISubCatalogRepositoryAsync _subCatalogRepository, IMapper _mapper)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<List<GetSubCatalogQueryResponse>> Handle(GetSubCatalogQueryRequest request, CancellationToken cancellationToken)
        {
            var response = new CommonResponse<List<GetSubCatalogQueryResponse>>();

            var subcatalogs = _subCatalogRepository.GetAllAsync();
            var list = _mapper.Map<List<GetSubCatalogQueryResponse>>(subcatalogs.Result.Value);
            return await Task.FromResult(list);
        }
    }
}
