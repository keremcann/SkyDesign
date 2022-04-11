using MediatR;
using SkyDesign.Application.Contract.Commands.Diagram;
using SkyDesign.Core.Base;
using SkyDesign.Domain.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SkyDesign.Application.Handlers.Diagram
{
    public class UpdateDiagramCommandHandler : IRequestHandler<UpdateDiagramCommandRequest, CommonResponse<UpdateDiagramCommandResponse>>
    {
        IDiagramRepositoryAsync _diagramRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="diagramRepository"></param>
        public UpdateDiagramCommandHandler(IDiagramRepositoryAsync diagramRepository)
        {
            _diagramRepository = diagramRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<CommonResponse<UpdateDiagramCommandResponse>> Handle(UpdateDiagramCommandRequest request, CancellationToken cancellationToken)
        {
            var response = new CommonResponse<UpdateDiagramCommandResponse>();
            var req = new Domain.Entities.Diagram
            {
                DiagramId = request.DiagramId,
                PageId = request.PageId,
                Name = request.Name,
                Nodes = request.Nodes,
                Edges = request.Edges,
                UpdateUser = "krmcn"
            };
            var diagrams = _diagramRepository.UpdateAsync(req);

            if (!diagrams.Result.Success)
            {
                response.Success = diagrams.Result.Success;
                response.ErrorMessage = diagrams.Result.ErrorMessage;
                return await Task.FromResult(response);
            }

            response.Success = diagrams.Result.Success;
            response.InfoMessage = diagrams.Result.InfoMessage;
            return await Task.FromResult(response);
        }
    }
}
