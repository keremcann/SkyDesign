using System;

namespace SkyDesign.Domain.Common
{
    public interface IEntity
    {
        string CreateUser { get; set; }
        DateTime CreateDate { get; set; }
        string UpdateUser { get; set; }
        DateTime? UpdateDate { get; set; }
        string DeleteUser { get; set; }
        DateTime? DeleteDate { get; set; }
        bool IsActive { get; set; }
    }
}
