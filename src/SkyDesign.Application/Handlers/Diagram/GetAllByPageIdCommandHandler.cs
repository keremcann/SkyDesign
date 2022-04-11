using AutoMapper;
using MediatR;
using SkyDesign.Application.Contract.Queries.Diagram;
using SkyDesign.Core.Base;
using SkyDesign.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SkyDesign.Application.Handlers.Diagram
{
    public class GetAllByPageIdCommandHandler : IRequestHandler<GetAllByPageIdQueryRequest, CommonResponse<List<GetAllByPageIdQueryResponse>>>
    {
        private readonly IMapper _mapper;
        private readonly IDiagramRepositoryAsync _diagramRepositoryAsync;

        public GetAllByPageIdCommandHandler(IMapper mapper, IDiagramRepositoryAsync diagramRepositoryAsync)
        {
            _mapper = mapper;
            _diagramRepositoryAsync = diagramRepositoryAsync;
        }

        public async Task<CommonResponse<List<GetAllByPageIdQueryResponse>>> Handle(GetAllByPageIdQueryRequest request, CancellationToken cancellationToken)
        {
            var response = new CommonResponse<List<GetAllByPageIdQueryResponse>>();

            var diagrams = _diagramRepositoryAsync.GetAllByPageIdAsync(request.PageId);
            if (!diagrams.Result.Success)
            {
                response.Success = diagrams.Result.Success;
                response.ErrorMessage = diagrams.Result.ErrorMessage;
                return await Task.FromResult(response);
            }

            response.Value = _mapper.Map<List<GetAllByPageIdQueryResponse>>(diagrams.Result.Value); ;
            response.Success = diagrams.Result.Success;
            response.ErrorMessage = diagrams.Result.InfoMessage;

            return await Task.FromResult(response);
        }
    }
}
