using MediatR;
using SkyDesign.Application.Contract.Queries.Page;
using SkyDesign.Core.Base;
using SkyDesign.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace SkyDesign.Application.Handlers.Page
{
    public class GetPageDetailQueryHandler : IRequestHandler<GetPageDetailQueryRequest, CommonResponse<GetPageDetailQueryResponse>>
    {
        IPageContentRepositoryAsync _pageContentRepositoryAsync;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageContentRepositoryAsync"></param>
        public GetPageDetailQueryHandler(IPageContentRepositoryAsync pageContentRepositoryAsync)
        {
            _pageContentRepositoryAsync = pageContentRepositoryAsync;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
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
                    Result = result.Value
                },
                Success = result.Success,
                InfoMessage = result.InfoMessage,
                ErrorMessage = result.ErrorMessage
            });
        }
    }
}
