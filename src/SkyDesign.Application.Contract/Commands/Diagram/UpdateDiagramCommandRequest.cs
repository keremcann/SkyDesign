using MediatR;
using SkyDesign.Core.Base;
using System;

namespace SkyDesign.Application.Contract.Commands.Diagram
{
    [Serializable]
    public class UpdateDiagramCommandRequest : IRequest<CommonResponse<UpdateDiagramCommandResponse>>
    {
        public int DiagramId { get; set; }
        public int PageId { get; set; }
        public string Name { get; set; }
        public string Nodes { get; set; }
        public string Edges { get; set; }
        public string RoteUrl { get; set; }
    }
}
