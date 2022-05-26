using SkyDesign.Core.Base;
using SkyDesign.Domain.Common;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkyDesign.Domain.Entities
{
    public class Page : BaseType, IEntity
    {
        public int PageId { get; set; }
        public int? ParentId { get; set; }
        [NotMapped]
        public int RoleId { get; set; }
        [NotMapped]
        public string TableName { get; set; }
        public bool IsCustom { get; set; }
        public string PageName { get; set; }
        public string Description { get; set; }
        public string PageIcon { get; set; }
        public string PageUrl { get; set; }
        public string CreateUser { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string DeleteUser { get; set; }
        public DateTime? DeleteDate { get; set; }
        public bool IsActive { get; set; }
    }
}
