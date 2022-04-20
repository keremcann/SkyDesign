using MediatR;
using SkyDesign.Core.Base;
using System;

namespace SkyDesign.Application.Contract.Commands.User
{
    [Serializable]
    public class UpdateUserCommandRequest : IRequest<CommonResponse<UpdateUserCommandResponse>>
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
