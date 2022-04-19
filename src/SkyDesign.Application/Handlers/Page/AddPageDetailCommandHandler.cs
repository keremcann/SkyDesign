using AutoMapper;
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
    public class AddPageDetailCommandHandler : IRequestHandler<AddPageDetailCommandRequest, CommonResponse<AddPageDetailCommandResponse>>
    {
        private readonly IPageContentRepositoryAsync _pageContentRepositoryAsync;
        private readonly IMapper _mapper;

        public AddPageDetailCommandHandler(IPageContentRepositoryAsync pageContentRepositoryAsync,
                                           IMapper mapper)
        {
            _pageContentRepositoryAsync = pageContentRepositoryAsync;
            _mapper = mapper;
        }

        public async Task<CommonResponse<AddPageDetailCommandResponse>> Handle(AddPageDetailCommandRequest request, CancellationToken cancellationToken)
        {
            //var mappedRequest = _mapper.Map<AddPageDetailCommandRequest, CatalogContent>(request);

            var result = await _pageContentRepositoryAsync.AddPageDetail(new CatalogContent
            {
                TableName = request.TableName,
                Items = request.Items.Select(x => new CatalogContentItem
                {
                    PropertyName = x.PropertyName,
                    PropertyValue = x.PropertyValue
                }).ToList()
            });

            return await Task.FromResult(new CommonResponse<AddPageDetailCommandResponse>
            {
                Success = result.Success,
                InfoMessage = result.InfoMessage,
                ErrorMessage = result.ErrorMessage
            });
        }
    }
}
