using MediatR;
using SkyDesign.Application.Contract.Commands.Page;
using SkyDesign.Core.Base;
using SkyDesign.Domain.CatalogBaseTypes;
using SkyDesign.Domain.Repositories;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SkyDesign.Application.Handlers.Page
{
    /// <summary>
    /// 
    /// </summary>
    public class DeletePageDetailCommandHandler : IRequestHandler<DeletePageDetailCommandRequest, CommonResponse<DeletePageDetailCommandResponse>>
    {
        private readonly IPageContentRepositoryAsync _pageContentRepositoryAsync;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageContentRepositoryAsync"></param>
        public DeletePageDetailCommandHandler(IPageContentRepositoryAsync pageContentRepositoryAsync)
        {
            _pageContentRepositoryAsync = pageContentRepositoryAsync;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<CommonResponse<DeletePageDetailCommandResponse>> Handle(DeletePageDetailCommandRequest request, CancellationToken cancellationToken)
        {
            var result = await _pageContentRepositoryAsync.DeletePageDetail(new CatalogContent
            {
                TableName = request.TableName,
                Items = request.Items.Select(x => new CatalogContentItem
                {
                    PropertyName = x.PropertyName,
                    PropertyValue = x.PropertyValue
                }).ToList()
            });

            return await Task.FromResult(new CommonResponse<DeletePageDetailCommandResponse>
            {
                Success = result.Success,
                InfoMessage = result.InfoMessage,
                ErrorMessage = result.ErrorMessage
            });
        }
    }
}
