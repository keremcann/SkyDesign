using SkyDesign.Core.Base;
using SkyDesign.Domain.Common;
using System;

namespace SkyDesign.Domain.Entities
{
    public class Catalog : BaseType, IEntity
    {
        public int CatalogId { get; set; }
        public string CatalogName { get; set; }
        public string CreateUser { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string DeleteUser { get; set; }
        public DateTime? DeleteDate { get; set; }
        public bool IsActive { get; set; }
    }
}
