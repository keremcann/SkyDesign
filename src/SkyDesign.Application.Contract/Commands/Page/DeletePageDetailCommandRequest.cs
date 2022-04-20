using MediatR;
using SkyDesign.Core.Base;
using System;
using System.Collections.Generic;

namespace SkyDesign.Application.Contract.Commands.Page
{
    [Serializable]
    public class DeletePageDetailCommandRequest : IRequest<CommonResponse<DeletePageDetailCommandResponse>>
    {
        public string TableName { get; set; }
        public int Id { get; set; }
    }
}
