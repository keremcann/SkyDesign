using MediatR;
using SkyDesign.Core.Base;
using System;
using System.Collections.Generic;

namespace SkyDesign.Application.Contract.Commands.Page
{
    [Serializable]
    public class CreatePageDetailCommandRequest : IRequest<CommonResponse<CreatePageDetailCommandResponse>>
    {
        public string TableName { get; set; }
        public List<PageContentType> Items { get; set; }
    }
}
