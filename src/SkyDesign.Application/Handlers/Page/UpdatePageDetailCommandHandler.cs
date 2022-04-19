using MediatR;
using SkyDesign.Application.Contract.Commands.Page;
using SkyDesign.Core.Base;
using SkyDesign.Domain.BaseTypes;
using SkyDesign.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SkyDesign.Application.Handlers.Page
{
    public class UpdatePageDetailCommandHandler : IRequestHandler<UpdatePageDetailCommand, CommonResponse<UpdatePageDetailCommandResponse>>
    {
        private readonly IPageContentRepositoryAsync _pageContentRepositoryAsync;

        public UpdatePageDetailCommandHandler(IPageContentRepositoryAsync pageContentRepositoryAsync)
        {
            _pageContentRepositoryAsync = pageContentRepositoryAsync;
        }

        public async Task<CommonResponse<UpdatePageDetailCommandResponse>> Handle(UpdatePageDetailCommand request, CancellationToken cancellationToken)
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
