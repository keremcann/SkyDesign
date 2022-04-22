using MediatR;
using SkyDesign.Core.Base;
using System;
using System.Collections.Generic;

namespace SkyDesign.Application.Contract.Commands.User
{
    [Serializable]
    public class UpdateUserCommandRequest : IRequest<CommonResponse<UpdateUserCommandResponse>>
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public List<UpdateUserCommandRequest_UserRoleDto> Roles { get; set; }
    }
    public class UpdateUserCommandRequest_UserRoleDto
    {
        public int RoleId { get; set; }
    }
}
