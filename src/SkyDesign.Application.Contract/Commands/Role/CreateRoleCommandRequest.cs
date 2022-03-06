using MediatR;
using SkyDesign.Core.Base;
using System;

namespace SkyDesign.Application.Contract.Commands.Role
{
    [Serializable]
    public class CreateRoleCommandRequest : IRequest<CommonResponse<CreateRoleCommandResponse>>
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
    }
}
