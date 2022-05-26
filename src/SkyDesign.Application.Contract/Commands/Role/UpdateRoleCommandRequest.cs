using MediatR;
using SkyDesign.Core.Base;
using System;

namespace SkyDesign.Application.Contract.Commands.Role
{
    [Serializable]
    public class UpdateRoleCommandRequest : IRequest<CommonResponse<UpdateRoleCommandResponse>>
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
    }
}
