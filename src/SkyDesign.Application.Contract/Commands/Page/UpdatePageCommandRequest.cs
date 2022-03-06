using MediatR;
using SkyDesign.Core.Base;
using System;

namespace SkyDesign.Application.Contract.Commands.Page
{
    [Serializable]
    public class UpdatePageCommandRequest : IRequest<CommonResponse<UpdatePageCommandResponse>>
    {
        public int PageId { get; set; }
        public int RoleId { get; set; }
        public string PageName { get; set; }
        public string Description { get; set; }
        public string PageIcon { get; set; }
        public string PageUrl { get; set; }
    }
}
