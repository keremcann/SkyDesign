using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyDesign.Application.Contract.Queries.Diagram
{
    [Serializable]
    public class GetAllByPageIdQueryResponse
    {
        public int DiagramId { get; set; }
        public int PageId { get; set; }
        public string Name { get; set; }
        public string Nodes { get; set; }
        public string Edges { get; set; }
        public string RoteUrl { get; set; }
    }
}
