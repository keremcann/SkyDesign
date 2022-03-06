using System;

namespace SkyDesign.Application.Contract.Commands.Role
{
    [Serializable]
    public class UpdateRoleCommandResponse
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
    }
}
