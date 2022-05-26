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
    public class GetAddOrUpdateModalDetailPageQueryHandler : IRequestHandler<GetAddOrUpdateModalDetailPageRequest, CommonResponse<GetAddOrUpdateModalDetailPageResponse>>
    {
        private readonly IPageRepositoryAsync _pageRepositoryAsync;
        private readonly IMapper _mapper;

        public GetAddOrUpdateModalDetailPageQueryHandler(IPageRepositoryAsync pageRepositoryAsync, IMapper mapper)
        {
            _pageRepositoryAsync = pageRepositoryAsync;
            _mapper = mapper;
        }

        public async Task<CommonResponse<GetAddOrUpdateModalDetailPageResponse>> Handle(GetAddOrUpdateModalDetailPageRequest request, CancellationToken cancellationToken)
        {
            string selectedPage = "";
            if (!string.IsNullOrWhiteSpace(request.Level3Menu)) selectedPage = request.Level3Menu;
            else if (!string.IsNullOrWhiteSpace(request.Level2Menu)) selectedPage = request.Level2Menu;
            else if (!string.IsNullOrWhiteSpace(request.Level1Menu)) selectedPage = request.Level1Menu;

            var fieldInfoList = await _pageRepositoryAsync.GetAddOrUpdateModalDetailPage(selectedPage, request.Id);

            var result = await Task.FromResult(new CommonResponse<GetAddOrUpdateModalDetailPageResponse>
            {
                ErrorMessage = fieldInfoList.ErrorMessage,
                InfoMessage = fieldInfoList.InfoMessage,
                Success = fieldInfoList.Success,
            });
            result.Value = new GetAddOrUpdateModalDetailPageResponse();
            result.Value.Result = fieldInfoList.Value;

            return result;
        }
    }
}
