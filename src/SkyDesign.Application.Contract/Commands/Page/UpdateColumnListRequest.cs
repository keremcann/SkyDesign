﻿using MediatR;
using SkyDesign.Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyDesign.Application.Contract.Commands.Page
{

    public class UpdateColumnListRequest : IRequest<CommonResponse<UpdateColumnListResponse>>
    {

    }
}
