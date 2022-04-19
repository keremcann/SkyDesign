using MediatR;
using SkyDesign.Core.Base;
using System.Collections.Generic;

namespace SkyDesign.Application.Contract.Commands.Page
{
    public class UpdatePageDetailCommand : IRequest<CommonResponse<UpdatePageDetailCommandResponse>>
    {
        public string TableName { get; set; }
        public List<AddPageDetailCommandRequestItem> Items { get; set; }
    }

    public class UpdatePageDetailCommandRequestItem
    {
        public string PropertyName { get; set; }
        public string PropertyValue { get; set; }
    }

    public class UpdatePageDetailCommandResponse
    {

    }
}
