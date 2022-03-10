using AutoMapper;
using MediatR;
using SkyDesign.Application.Contract.Queries.SubCatalogDetail;
using SkyDesign.Core.Base;
using SkyDesign.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SkyDesign.Application.Handlers.SubCatalogDetail
{
    public class GetSubCatalogDetailBySubCategoryIdQueryHandler : IRequestHandler<GetSubCatalogDetailBySubCatalogIdQueryRequest, CommonResponse<List<GetSubCatalogDetailBySubCatalogIdQueryResponse>>>
    {
        ISubCatalogDetailRepositoryAsync _subCatalogDetailRepository;
        IMapper _mapper;

        public GetSubCatalogDetailBySubCategoryIdQueryHandler(ISubCatalogDetailRepositoryAsync subCatalogDetailRepository, IMapper mapper)
        {
            _subCatalogDetailRepository = subCatalogDetailRepository;
            _mapper = mapper;
        }

        public async Task<CommonResponse<List<GetSubCatalogDetailBySubCatalogIdQueryResponse>>> Handle(GetSubCatalogDetailBySubCatalogIdQueryRequest request, CancellationToken cancellationToken)
        {
            var response = new CommonResponse<List<GetSubCatalogDetailBySubCatalogIdQueryResponse>>();

            var catalogs = _subCatalogDetailRepository.GetAllBySubCatalogIdAsync(request.SubCatalogId);
            var list = _mapper.Map<List<GetSubCatalogDetailBySubCatalogIdQueryResponse>>(catalogs.Result.Value);
            response.Value = list;
            return await Task.FromResult(response);
        }
    }
}