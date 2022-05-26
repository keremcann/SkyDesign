using SkyDesign.Core.Base;
using SkyDesign.Domain.Common;
using System;

namespace SkyDesign.Domain.Entities
{
    public class SubCatalogDetail : BaseType, IEntity
    {
        public int SubCatalogDetailId { get; set; }
        public int SubCatalogId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public string CreateUser { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string DeleteUser { get; set; }
        public DateTime? DeleteDate { get; set; }
        public bool IsActive { get; set; }
    }
}
