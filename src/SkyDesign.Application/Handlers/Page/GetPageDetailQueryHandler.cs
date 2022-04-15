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
    public class GetPageDetailQueryHandler : IRequestHandler<GetPageDetailQueryRequest, CommonResponse<GetPageDetailQueryResponse>>
    {
        IPageContentRepositoryAsync _pageContentRepositoryAsync;

        public GetPageDetailQueryHandler(IPageContentRepositoryAsync pageContentRepositoryAsync)
        {
            _pageContentRepositoryAsync = pageContentRepositoryAsync;
        }

        public async Task<CommonResponse<GetPageDetailQueryResponse>> Handle(GetPageDetailQueryRequest request, CancellationToken cancellationToken)
        {

            string selectedPage = "";
            if (!string.IsNullOrWhiteSpace(request.Level3Menu)) selectedPage = request.Level3Menu;
            else if (!string.IsNullOrWhiteSpace(request.Level2Menu)) selectedPage = request.Level2Menu;
            else if (!string.IsNullOrWhiteSpace(request.Level1Menu)) selectedPage = request.Level1Menu;

            var result = await _pageContentRepositoryAsync.GetPageDetail(selectedPage);

            return await Task.FromResult(new CommonResponse<GetPageDetailQueryResponse>
            {
                Value = new GetPageDetailQueryResponse
                {
                    Result = result
                },
                Success = true,
                InfoMessage = "Successful"
            });
        }
    }
}
