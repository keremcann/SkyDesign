using System;

namespace SkyDesign.Application.Contract.Queries.Diagram
{
    [Serializable]
    public class GetDiagramQueryResponse
    {
        public int DiagramId { get; set; }
        public int PageId { get; set; }
        public string Name { get; set; }
        public string Nodes { get; set; }
        public string Edges { get; set; }
        public string RoteUrl { get; set; }
    }
}
