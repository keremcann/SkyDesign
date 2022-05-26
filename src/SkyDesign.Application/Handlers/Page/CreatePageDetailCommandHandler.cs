using AutoMapper;
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
    public class CreatePageDetailCommandHandler : IRequestHandler<CreatePageDetailCommandRequest, CommonResponse<CreatePageDetailCommandResponse>>
    {
        private readonly IPageContentRepositoryAsync _pageContentRepositoryAsync;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageContentRepositoryAsync"></param>
        public CreatePageDetailCommandHandler(IPageContentRepositoryAsync pageContentRepositoryAsync)
        {
            _pageContentRepositoryAsync = pageContentRepositoryAsync;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<CommonResponse<CreatePageDetailCommandResponse>> Handle(CreatePageDetailCommandRequest request, CancellationToken cancellationToken)
        {
            var result = await _pageContentRepositoryAsync.CreatePageDetail(new CatalogContent
            {
                TableName = request.TableName,
                Items = request.Items.Select(x => new CatalogContentItem
                {
                    PropertyName = x.PropertyName,
                    PropertyValue = x.PropertyValue
                }).ToList()
            });

            return await Task.FromResult(new CommonResponse<CreatePageDetailCommandResponse>
            {
                Success = result.Success,
                InfoMessage = result.InfoMessage,
                ErrorMessage = result.ErrorMessage
            });
        }
    }
}
