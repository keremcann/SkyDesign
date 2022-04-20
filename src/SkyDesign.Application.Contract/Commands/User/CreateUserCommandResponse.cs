using System;

namespace SkyDesign.Application.Contract.Commands.User
{
    [Serializable]
    public class CreateUserCommandResponse
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}
