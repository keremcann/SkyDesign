using MediatR;
using SkyDesign.Core.Base;
using System;

namespace SkyDesign.Application.Contract.Commands.Role
{
    [Serializable]
    public class CreateRoleCommandRequest : IRequest<CommonResponse<CreateRoleCommandResponse>>
    {
        public string RoleName { get; set; }
        public string Description { get; set; }
    }
}
