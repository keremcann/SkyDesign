using System;

namespace SkyDesign.Application.Contract.Queries.Role
{
    [Serializable]
    public class GetRoleQueryResponse
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
