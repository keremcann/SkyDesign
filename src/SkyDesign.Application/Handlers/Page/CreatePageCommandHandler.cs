using AutoMapper;
using MediatR;
using SkyDesign.Application.Contract.Commands.Page;
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
    public class CreatePageCommandHandler : IRequestHandler<CreatePageCommandRequest, CommonResponse<CreatePageCommandResponse>>
    {
        private readonly IPageRepositoryAsync _pageRepositoryAsync;
        private readonly IMapper _mapper;

        public CreatePageCommandHandler(IPageRepositoryAsync pageRepositoryAsync,
                                        IMapper mapper)
        {
            _mapper = mapper;
            _pageRepositoryAsync = pageRepositoryAsync;
        }
        public async Task<CommonResponse<CreatePageCommandResponse>> Handle(CreatePageCommandRequest request, CancellationToken cancellationToken)
        {
            var mappedPage = _mapper.Map<Domain.Entities.Page>(request);

            var result = await _pageRepositoryAsync.AddAsync(mappedPage);

            _ = await _pageRepositoryAsync.CreateDefaultTable(mappedPage);

            return new CommonResponse<CreatePageCommandResponse>
            {
                Success = result.Success,
                ErrorMessage = result.ErrorMessage,
                InfoMessage = result.InfoMessage,
            };
        }
    }
}