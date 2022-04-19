using MediatR;
using SkyDesign.Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyDesign.Application.Contract.Commands.Page
{
    public class AddPageDetailCommandRequest : IRequest<CommonResponse<AddPageDetailCommandResponse>>
    {
        public string TableName { get; set; }
        public List<AddPageDetailCommandRequestItem> Items { get; set; }
    }

    public class AddPageDetailCommandRequestItem
    {
        public string PropertyName { get; set; }
        public string PropertyValue { get; set; }
    }

    public class AddPageDetailCommandResponse
    {

    }
}