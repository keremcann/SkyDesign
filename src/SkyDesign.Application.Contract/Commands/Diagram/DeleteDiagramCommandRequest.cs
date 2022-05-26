using MediatR;
using SkyDesign.Core.Base;
using System;

namespace SkyDesign.Application.Contract.Commands.Diagram
{
    [Serializable]
    public class DeleteDiagramCommandRequest : IRequest<CommonResponse<DeleteDiagramCommandResponse>>
    {
        public int DiagramId { get; set; }
        public int PageId { get; set; }
    }
}
