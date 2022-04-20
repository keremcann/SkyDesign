using MediatR;
using SkyDesign.Core.Base;
using System;

namespace SkyDesign.Application.Contract.Commands.User
{
    [Serializable]
    public class DeleteUserCommandRequest : IRequest<CommonResponse<DeleteUserCommandResponse>>
    {
        public int UserId { get; set; }
    }
}
