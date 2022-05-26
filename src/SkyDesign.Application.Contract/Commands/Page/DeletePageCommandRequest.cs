using MediatR;
using SkyDesign.Core.Base;
using System;

namespace SkyDesign.Application.Contract.Commands.Page
{
    [Serializable]
    public class DeletePageCommandRequest : IRequest<CommonResponse<DeletePageCommandResponse>>
    {
        public int PageId { get; set; }
        public int RoleId { get; set; }
    }
}
