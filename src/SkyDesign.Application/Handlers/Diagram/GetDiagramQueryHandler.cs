using AutoMapper;
using MediatR;
using SkyDesign.Application.Contract.Queries.Diagram;
using SkyDesign.Core.Base;
using SkyDesign.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SkyDesign.Application.Handlers.Diagram
{
    public class GetDiagramQueryHandler : IRequestHandler<GetDiagramQueryRequest, CommonResponse<List<GetDiagramQueryResponse>>>
    {
        IDiagramRepositoryAsync _diagramRepository;
        IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="catalogRepository"></param>
        /// <param name="mapper"></param>
        public GetDiagramQueryHandler(IDiagramRepositoryAsync diagramRepository, IMapper mapper)
        {
            _diagramRepository = diagramRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<CommonResponse<List<GetDiagramQueryResponse>>> Handle(GetDiagramQueryRequest request, CancellationToken cancellationToken)
        {
            var response = new CommonResponse<List<GetDiagramQueryResponse>>();

            var diagrams = _diagramRepository.GetAllAsync();
            if (!diagrams.Result.Success)
            {
                response.Success = diagrams.Result.Success;
                response.ErrorMessage = diagrams.Result.ErrorMessage;
                return await Task.FromResult(response);
            }
            var list = _mapper.Map<List<GetDiagramQueryResponse>>(diagrams.Result.Value);
            response.Value = list;
            response.Success = diagrams.Result.Success;
            response.ErrorMessage = diagrams.Result.InfoMessage;
            return await Task.FromResult(response);
        }
    }
}
