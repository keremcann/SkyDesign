using SkyDesign.Core.Base;
using SkyDesign.Domain.Common;
using System;

namespace SkyDesign.Domain.Entities
{
    public class Diagram : BaseType, IEntity
    {
        public int DiagramId { get; set; }
        public int PageId { get; set; }
        public string Name { get; set; }
        public string Nodes { get; set; }
        public string Edges { get; set; }
        public string RoteUrl { get; set; }
        public string CreateUser { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string DeleteUser { get; set; }
        public DateTime? DeleteDate { get; set; }
        public bool IsActive { get; set; }
    }
}
