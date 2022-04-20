using SkyDesign.Core.Base;
using SkyDesign.Domain.Common;
using System;

namespace SkyDesign.Domain.Entities
{
    public class User : BaseType, IEntity
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string CreateUser { get ; set; }
        public DateTime CreateDate { get; set; }
        public string UpdateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string DeleteUser { get; set; }
        public DateTime? DeleteDate { get ; set; }
        public bool IsActive { get; set; }
    }
}
