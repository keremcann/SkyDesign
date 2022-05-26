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
    public class UpdatePageDetailCommandHandler : IRequestHandler<UpdatePageDetailCommandRequest, CommonResponse<UpdatePageDetailCommandResponse>>
    {
        private readonly IPageContentRepositoryAsync _pageContentRepositoryAsync;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageContentRepositoryAsync"></param>
        public UpdatePageDetailCommandHandler(IPageContentRepositoryAsync pageContentRepositoryAsync)
        {
            _pageContentRepositoryAsync = pageContentRepositoryAsync;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<CommonResponse<UpdatePageDetailCommandResponse>> Handle(UpdatePageDetailCommandRequest request, CancellationToken cancellationToken)
        {
            var result = await _pageContentRepositoryAsync.UpdatePageDetail(new CatalogContent
            {
                TableName = request.TableName,
                Items = request.Items.Select(x => new CatalogContentItem
                {
                    PropertyName = x.PropertyName,
                    PropertyValue = x.PropertyValue
                }).ToList()
            });

            return await Task.FromResult(new CommonResponse<UpdatePageDetailCommandResponse>
            {
                Success = result.Success,
                InfoMessage = result.InfoMessage,
                ErrorMessage = result.ErrorMessage
            });
        }
    }
}
