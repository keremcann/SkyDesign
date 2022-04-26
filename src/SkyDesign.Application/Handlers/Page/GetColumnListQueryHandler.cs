using AutoMapper;
using MediatR;
using SkyDesign.Application.Contract.Queries.Page;
using SkyDesign.Core.Base;
using SkyDesign.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SkyDesign.Application.Handlers.Page
{
    class GetColumnListQueryHandler : IRequestHandler<GetColumnListRequest, CommonResponse<List<GetColumnListResponse>>>
    {
        private readonly IMapper _mapper;
        private readonly IPageRepositoryAsync _pageRepositoryAsync;

        public GetColumnListQueryHandler(IMapper mapper,
                                         IPageRepositoryAsync pageRepositoryAsync)
        {
            _mapper = mapper;
            _pageRepositoryAsync = pageRepositoryAsync;
        }
        public async Task<CommonResponse<List<GetColumnListResponse>>> Handle(GetColumnListRequest request, CancellationToken cancellationToken)
        {
            var columnList = await _pageRepositoryAsync.GetAllColumnListAsync();

            var mappedColumnList = _mapper.Map<List<GetColumnListResponse>>(columnList.Value);

            return await Task.FromResult(new CommonResponse<List<GetColumnListResponse>>
            {
                Success = columnList.Success,
                ErrorMessage = columnList.ErrorMessage,
                InfoMessage = columnList.InfoMessage,
                Value = mappedColumnList
            });
        }
    }
}