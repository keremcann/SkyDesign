using MediatR;
using SkyDesign.Application.Contract.Commands.Diagram;
using SkyDesign.Core.Base;
using SkyDesign.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace SkyDesign.Application.Handlers.Diagram
{
    public class DeleteDiagramCommandHandler : IRequestHandler<DeleteDiagramCommandRequest, CommonResponse<DeleteDiagramCommandResponse>>
    {
        IDiagramRepositoryAsync _diagramRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="diagramRepository"></param>
        public DeleteDiagramCommandHandler(IDiagramRepositoryAsync diagramRepository)
        {
            _diagramRepository = diagramRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<CommonResponse<DeleteDiagramCommandResponse>> Handle(DeleteDiagramCommandRequest request, CancellationToken cancellationToken)
        {
            var response = new CommonResponse<DeleteDiagramCommandResponse>();
            var req = new Domain.Entities.Diagram
            {
                DiagramId = request.DiagramId,
                PageId = request.PageId,
                DeleteUser = "krmcn"
            };
            var diagrams = _diagramRepository.DeleteAsync(req);

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
