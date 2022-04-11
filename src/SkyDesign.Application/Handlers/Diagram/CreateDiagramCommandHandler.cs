using MediatR;
using SkyDesign.Application.Contract.Commands.Diagram;
using SkyDesign.Core.Base;
using SkyDesign.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace SkyDesign.Application.Handlers.Diagram
{
    public class CreateDiagramCommandHandler : IRequestHandler<CreateDiagramCommandRequest, CommonResponse<CreateDiagramCommandResponse>>
    {
        IDiagramRepositoryAsync _diagramRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="diagramRepository"></param>
        public CreateDiagramCommandHandler(IDiagramRepositoryAsync diagramRepository)
        {
            _diagramRepository = diagramRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<CommonResponse<CreateDiagramCommandResponse>> Handle(CreateDiagramCommandRequest request, CancellationToken cancellationToken)
        {
            var response = new CommonResponse<CreateDiagramCommandResponse>();
            var req = new Domain.Entities.Diagram
            {
                PageId = request.PageId,
                Nodes = request.Nodes,
                Edges = request.Edges,
                Name = request.Name,
                CreateUser = "krmcn"
            };
            var diagrams = _diagramRepository.AddAsync(req);

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
