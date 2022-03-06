using SkyDesign.Core.Base;
using SkyDesign.Domain.Common;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkyDesign.Domain.Entities
{
    public class Role : BaseType, IEntity
    {
        public int RoleId { get; set; }
        [NotMapped]
        public int UserId { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
        public string CreateUser { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string DeleteUser { get; set; }
        public DateTime? DeleteDate { get; set; }
        public bool IsActive { get; set; }
    }
}
