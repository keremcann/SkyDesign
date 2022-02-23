using SkyDesign.Core.Base;
using SkyDesign.Domain.Common;
using System;

namespace SkyDesign.Domain.Entities
{
    public class SubCatalog : BaseType, IEntity
    {
        public int SubCatalogId { get; set; }
        public int CatalogId { get; set; }
        public string SubCatalogName { get; set; }
        public string CreateUser { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string DeleteUser { get; set; }
        public DateTime? DeleteDate { get; set; }
        public bool IsActive { get; set; }
    }
}
