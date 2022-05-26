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
    public class GetAllColumnListByPageIdRequestHandler : IRequestHandler<GetAllColumnListByPageIdRequest, CommonResponse<List<GetAllColumnListByPageIdResponse>>>
    {
        private readonly IMapper _mapper;
        private readonly IPageRepositoryAsync _pageRepositoryAsync;

        public GetAllColumnListByPageIdRequestHandler(IMapper mapper, IPageRepositoryAsync pageRepositoryAsync)
        {
            _mapper = mapper;
            _pageRepositoryAsync = pageRepositoryAsync;
        }
        public async Task<CommonResponse<List<GetAllColumnListByPageIdResponse>>> Handle(GetAllColumnListByPageIdRequest request, CancellationToken cancellationToken)
        {
            var columnList = await _pageRepositoryAsync.GetAllColumnListByPageId(request.PageId);

            var result = _mapper.Map<List<GetAllColumnListByPageIdResponse>>(columnList.Value);

            return await Task.FromResult(new CommonResponse<List<GetAllColumnListByPageIdResponse>>
            {
                Value = result,
                ErrorMessage = columnList.ErrorMessage,
                InfoMessage = columnList.InfoMessage,
                Success = columnList.Success,
            });
        }
    }
}
