using MediatR;
using SkyDesign.Core.Base;
using System;
using System.Collections.Generic;

namespace SkyDesign.Application.Contract.Commands.User
{
    [Serializable]
    public class CreateUserCommandRequest : IRequest<CommonResponse<CreateUserCommandResponse>>
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public List<CreateUserCommandRequest_UserRoleDto> Roles { get; set; }
    }

    public class CreateUserCommandRequest_UserRoleDto
    {
        public int RoleId { get; set; }
    }
}
