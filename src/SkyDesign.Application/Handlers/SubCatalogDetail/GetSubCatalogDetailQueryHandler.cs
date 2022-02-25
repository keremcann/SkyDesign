using AutoMapper;
using MediatR;
using SkyDesign.Application.Contract.Queries.SubCatalogDetail;
using SkyDesign.Core.Base;
using SkyDesign.Domain.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SkyDesign.Application.Handlers.SubCatalogDetail
{
    public class GetSubCatalogDetailQueryHandler : IRequestHandler<GetSubCatalogDetailQueryRequest, CommonResponse<List<GetSubCatalogDetailQueryResponse>>>
    {
        ISubCatalogDetailRepositoryAsync _subCatalogDetailRepository;
        IMapper _mapper;

        public GetSubCatalogDetailQueryHandler(ISubCatalogDetailRepositoryAsync subCatalogDetailRepository, IMapper mapper)
        {
            _subCatalogDetailRepository = subCatalogDetailRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<CommonResponse<List<GetSubCatalogDetailQueryResponse>>> Handle(GetSubCatalogDetailQueryRequest request, CancellationToken cancellationToken)
        {
            var response = new CommonResponse<List<GetSubCatalogDetailQueryResponse>>();

            var catalogs = _subCatalogDetailRepository.GetAllAsync();
            var list = _mapper.Map<List<GetSubCatalogDetailQueryResponse>>(catalogs.Result.Value);
            response.Value = list;
            return await Task.FromResult(response);
        }
    }
}
